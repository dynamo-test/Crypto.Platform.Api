using AutoMapper;
using Crypto.Platform.Api.Boundary.Request.Class;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Api.Extensions.Factories
{
    public static class FileUploadFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static FileUploadDto ToRequest(this FileUploadQuery model)
        {
            return _mapper.Map<FileUploadDto>(model);
        }

        public static FileUploadResponse ToResponse(this MetaDataDto model) 
        {
            return _mapper.Map<FileUploadResponse>(model);
        }
    }
}
