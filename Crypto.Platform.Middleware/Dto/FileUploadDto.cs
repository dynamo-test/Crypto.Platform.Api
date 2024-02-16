using Microsoft.AspNetCore.Http;

namespace Crypto.Platform.Middleware.Dto
{
    public class FileUploadDto
    {
        public IFormFile content { get; set; } = null!;
    }
}
