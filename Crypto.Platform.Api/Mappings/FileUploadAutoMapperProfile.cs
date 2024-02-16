using AutoMapper;
using Crypto.Platform.Api.Boundary.Request.Class;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Api.Mappings
{
    public class FileUploadAutoMapperProfile : Profile
    {
        public FileUploadAutoMapperProfile() 
        {
            CreateMap<FileUploadQuery, FileUploadDto>();

            CreateMap<MetaDataDto, FileUploadResponse>();
        }
    }
}
