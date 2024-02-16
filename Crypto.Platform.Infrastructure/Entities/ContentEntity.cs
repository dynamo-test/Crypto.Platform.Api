namespace Crypto.Platform.Infrastructure.Entities
{
    public class ContentEntity
    {
        public double Count { get; set; }

        public string Type { get; set; } = null!;

        public decimal UnitPrice { get; set; }
    }
}
