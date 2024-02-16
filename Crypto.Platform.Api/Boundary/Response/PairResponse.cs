using Newtonsoft.Json;

namespace Crypto.Platform.Api.Boundary.Response
{
    public class PairResponse
    {
        [JsonProperty("base")]
        public string Base { get; set; } = null!;

        [JsonProperty("quote")]
        public string Quote { get; set; } = null!;

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("price_usd")]
        public decimal PriceUSD { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}
