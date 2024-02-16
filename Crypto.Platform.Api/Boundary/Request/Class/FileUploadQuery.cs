using Crypto.Platform.Api.Boundary.Request.Abstract;

namespace Crypto.Platform.Api.Boundary.Request.Class
{
    public class FileUploadQuery : RequestViewModel
    {
        public IFormFile content { get; set; } = null!;
    }
}
