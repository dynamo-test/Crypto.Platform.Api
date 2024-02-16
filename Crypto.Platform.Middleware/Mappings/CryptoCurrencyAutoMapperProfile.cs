using AutoMapper;
using Crypto.Platform.Infrastructure.Entities;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Middleware.Mappings
{
    public class CryptoCurrencyAutoMapperProfile : Profile
    {
        public CryptoCurrencyAutoMapperProfile()
        {
            CreateMap<ContentEntity, CryptoCurrencyDto>();
        }
    }
}
