using AutoMapper;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Middleware.Dto;

namespace Crypto.Platform.Api.Extensions.Factories
{
    public static class CryptoCurrencyFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IList<CryptoCurrencyResponse> ToResponse(this IList<CryptoCurrencyDto> model)
        {
            return model.Select(ToResponse).ToList();
        }

        public static CryptoCurrencyResponse ToResponse(this CryptoCurrencyDto model)
        {
            return _mapper.Map<CryptoCurrencyResponse>(model);
        }
    }
}
