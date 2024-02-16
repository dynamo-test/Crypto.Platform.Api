using Crypto.Platform.Infrastructure.Patterns.Repository.Interface;
using Crypto.Platform.Middleware.Dto;
using Crypto.Platform.Middleware.Extensions.Factories;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.Platform.Middleware.Gateways
{
    internal class FileUploadApiGateway : IFileUploadProxy
    {
        private readonly IContentRepository _contentRepository;

        public FileUploadApiGateway(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._contentRepository = scope.ServiceProvider.GetRequiredService<IContentRepository>();

        }

        public async Task<MetaDataDto> SetFileUploadedContentAsync(FileUploadDto requestDto)
        {

            using (var reader = new StreamReader(requestDto.content.OpenReadStream()))
            {
                if (this._contentRepository.GetCount() != 0 ) this._contentRepository.RemoveContent();

                while (reader.Peek() >= 0)
                {
                    var data = await reader.ReadLineAsync();

                    if (!string.IsNullOrEmpty(data))
                    {
                        this._contentRepository.AddContent(data.ToParse());
                    }

                }
            }

            return requestDto.ToResult();
        }
    }
}
