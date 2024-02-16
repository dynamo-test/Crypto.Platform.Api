using Newtonsoft.Json;

namespace Crypto.Platform.Api.Boundary.Response
{
    public class ExchangeResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("name_id")]
        public string NameId { get; set; } = null!;

        [JsonProperty("volume_usd")]
        public decimal VolumeUSD { get; set; }

        [JsonProperty("active_pairs")]
        public int ActivePairs { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; } = null!;

        [JsonProperty("country")]
        public string Country { get; set; } = null!;
    }
}