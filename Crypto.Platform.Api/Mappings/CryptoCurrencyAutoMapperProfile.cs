using AutoMapper;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Api.Mappings
{
    public class CryptoCurrencyAutoMapperProfile : Profile
    {
        public CryptoCurrencyAutoMapperProfile()
        {
            CreateMap<CryptoCurrencyDto, CryptoCurrencyResponse>();
        }
    }
}
