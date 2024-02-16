using AutoMapper;
using Crypto.Platform.Infrastructure.Entities;

namespace Crypto.Platform.Middleware.Extensions.Factories
{
    public static class ContentEntityFactory
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IMapper _mapper;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static ContentEntity ToParse(this string data)
        {
            var info = data.Split("|");

            if (info.Length < 3) throw new Exception("Invalid data format");

            return _mapper.Map<ContentEntity>(info);
        }
    }
}
