using Crypto.Platform.Middleware.Dto;
using Crypto.Platform.Middleware.Gateways;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;

namespace Crypto.Platform.Middleware.Patterns.Proxy.Class
{
    public class CryptoCurrencyProxy : ICryptoCurrencyProxy
    {
        #region Properties
        private readonly CryptoCurrencyApiGateway _cryptoCurrencyApiGateway;
        #endregion

        public CryptoCurrencyProxy(IServiceProvider provider)
        {
            this._cryptoCurrencyApiGateway = new CryptoCurrencyApiGateway(provider);
        }

        public async Task<IList<CryptoCurrencyDto>> GetAllCryptoCurrencyAsync()
        {
            return await this._cryptoCurrencyApiGateway.GetAllCryptoCurrencyAsync();
        }
    }
}
