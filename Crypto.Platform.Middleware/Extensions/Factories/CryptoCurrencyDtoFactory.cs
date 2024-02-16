using AutoMapper;
using Crypto.Platform.Infrastructure.Entities;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Middleware.Extensions.Factories
{
    public static class CryptoCurrencyDtoFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IList<CryptoCurrencyDto> ToResult(this IList<ContentEntity> entities)
        {
            return entities.Select(ToResult).ToList();
        }

        public static CryptoCurrencyDto ToResult(this ContentEntity entity)
        {
            return _mapper.Map<CryptoCurrencyDto>(entity);
        }
    }
}
