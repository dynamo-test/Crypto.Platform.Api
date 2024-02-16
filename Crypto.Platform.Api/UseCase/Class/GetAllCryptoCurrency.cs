using Crypto.Platform.Api.Boundary.Request.Abstract;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.Extensions.Factories;
using Crypto.Platform.Api.UseCase.Abstract;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;

namespace Crypto.Platform.Api.UseCase.Class
{
    public class GetAllCryptoCurrency : BaseUseCase<IList<CryptoCurrencyResponse>>
    {
        private readonly ICryptoCurrencyProxy _cryptoCurrencyProxy;

        public GetAllCryptoCurrency(ICryptoCurrencyProxy cryptoCurrencyProxy)
        {
            this._cryptoCurrencyProxy = cryptoCurrencyProxy;
        }

        public override async Task<IList<CryptoCurrencyResponse>> ExecuteAsync(RequestViewModel? request)
        {
            var cryptoCurrencies = await this._cryptoCurrencyProxy.GetAllCryptoCurrencyAsync();

            return cryptoCurrencies.ToResponse();
        }
    }
}
