using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Middleware.Patterns.Proxy.Interface
{
    public interface ICryptoCurrencyProxy
    {
        Task<IList<CryptoCurrencyDto>> GetAllCryptoCurrencyAsync();
    }
}
