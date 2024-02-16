using Crypto.Platform.Api.Boundary.Request.Abstract;

namespace Crypto.Platform.Api.Boundary.Request.Class
{
    public class ExchangeItemQuery : RequestViewModel
    {
        public string Id { get; set; } = null!;
    }
}
