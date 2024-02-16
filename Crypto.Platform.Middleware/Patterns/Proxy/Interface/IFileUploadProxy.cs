using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Middleware.Patterns.Proxy.Interface
{
    public interface IFileUploadProxy
    {
        Task<MetaDataDto> SetFileUploadedContentAsync(FileUploadDto requestDto);
    }
}
