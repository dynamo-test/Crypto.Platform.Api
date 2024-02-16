using AutoMapper;
using Crypto.Platform.Middleware.Dto;
using Microsoft.AspNetCore.Http;

namespace Crypto.Platform.Middleware.Mappings
{
    public class MetaDataAutoMapperProfile : Profile
    {
        public MetaDataAutoMapperProfile()
        {
            CreateMap<MetaDataDto, IFormFile>()
                .ReverseMap()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length));
        }
    }
}
