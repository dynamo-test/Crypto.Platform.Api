using Crypto.Platform.Middleware.Dto;
using Crypto.Platform.Middleware.Gateways;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;

namespace Crypto.Platform.Middleware.Patterns.Proxy.Class
{
    public class FileUploadProxy : IFileUploadProxy
    {
        #region Properties
        private readonly FileUploadApiGateway _fileUploadApiGateway;
        #endregion

        public FileUploadProxy(IServiceProvider provider)
        {
            this._fileUploadApiGateway = new FileUploadApiGateway(provider);
        }

        public async Task<MetaDataDto> SetFileUploadedContentAsync(FileUploadDto requestDto)
        {
            return await this._fileUploadApiGateway.SetFileUploadedContentAsync(requestDto);
        }
    }
}
