using Crypto.Platform.Infrastructure.Patterns.Repository.Interface;
using Crypto.Platform.Middleware.Dto;
using Crypto.Platform.Middleware.Extensions.Factories;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.Platform.Middleware.Gateways
{
    internal class CryptoCurrencyApiGateway :  ICryptoCurrencyProxy
    {
        private readonly IContentRepository _contentRepository;

        public CryptoCurrencyApiGateway(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._contentRepository = scope.ServiceProvider.GetRequiredService<IContentRepository>();

        }

        public async Task<IList<CryptoCurrencyDto>> GetAllCryptoCurrencyAsync()
        {

            var cryptoCurrencies = await Task.FromResult(this._contentRepository.GetContent());

            return cryptoCurrencies.ToResult();
        }
    }
}
