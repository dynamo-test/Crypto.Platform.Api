namespace Crypto.Platform.Middleware.Dto
{
    public class CryptoCurrencyDto
    {
        public double Count { get; set; }

        public string Type { get; set; } = null!;

        public decimal UnitPrice { get; set; }
    }
}
