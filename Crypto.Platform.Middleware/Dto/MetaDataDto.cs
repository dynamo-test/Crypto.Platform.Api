namespace Crypto.Platform.Middleware.Dto
{
    public class MetaDataDto
    {
        public string FileName { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public long Size { get; set; }
    }
}
