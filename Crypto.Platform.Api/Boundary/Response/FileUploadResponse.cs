using Newtonsoft.Json;

namespace Crypto.Platform.Api.Boundary.Response
{
    public class FileUploadResponse
    {
        [JsonProperty("file")]
        public string FileName { get; set; } = null!;

        [JsonProperty("type")]
        public string ContentType { get; set; } = null!;

        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
