using Newtonsoft.Json;

namespace Crypto.Platform.Api.Boundary.Response
{
    public class ExchangeItemResponse
    {
        [JsonProperty("pairs")]
        public IList<PairResponse> Pairs { get; set; } = null!;
    }
}
