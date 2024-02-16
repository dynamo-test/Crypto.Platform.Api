using Crypto.Platform.Api.Boundary.Request.Abstract;
using Crypto.Platform.Api.Boundary.Request.Class;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.Extensions.Factories;
using Crypto.Platform.Api.UseCase.Abstract;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;

namespace Crypto.Platform.Api.UseCase.Class
{
    public class SetFileUploadedContent : BaseUseCase<FileUploadResponse>
    {
        private readonly IFileUploadProxy _fileUploadProxy;

        public SetFileUploadedContent(IFileUploadProxy fileUploadProxy)
        {
            this._fileUploadProxy = fileUploadProxy;
        }

        public override async Task<FileUploadResponse> ExecuteAsync(RequestViewModel? request)
        {
            var requestDto = ((FileUploadQuery)request!).ToRequest();

            var metaData = await this._fileUploadProxy.SetFileUploadedContentAsync(requestDto);

            return metaData.ToResponse();
        }
    }
}
