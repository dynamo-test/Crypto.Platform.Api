using Newtonsoft.Json;

namespace Crypto.Platform.Api.Boundary.Response
{
    public class CryptoCurrencyResponse
    {

        [JsonProperty("count")]
        public double Count { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}
