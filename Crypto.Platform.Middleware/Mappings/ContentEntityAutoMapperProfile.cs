using AutoMapper;
using Crypto.Platform.Infrastructure.Entities;

namespace Crypto.Platform.Middleware.Mappings
{
    public class ContentEntityAutoMapperProfile : Profile
    {
        public ContentEntityAutoMapperProfile()
        {
            CreateMap<string[], ContentEntity>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src[0]))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src[1]))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src[2]));
        }
    }
}
