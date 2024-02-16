using AutoMapper;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Middleware.Extensions.Factories
{
    public static class MetaDataDtoFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static MetaDataDto ToResult(this FileUploadDto model)
        {
            return _mapper.Map<MetaDataDto>(model.content);
        }
    }
}
