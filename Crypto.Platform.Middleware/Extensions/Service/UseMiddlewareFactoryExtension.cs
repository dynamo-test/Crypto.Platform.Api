using AutoMapper;
using Crypto.Platform.Middleware.Extensions.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Crypto.Platform.Infrastructure.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class UseMiddlewareFactoryExtension
    {
        public static void UseMiddlewareFactory(this WebApplication app)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            MetaDataDtoFactory.Configure(app.Services.GetService<IMapper>());
            CryptoCurrencyDtoFactory.Configure(app.Services.GetService<IMapper>());
            ContentEntityFactory.Configure(app.Services.GetService<IMapper>());
#pragma warning restore CS8604 // Possible null reference argument.

        }
    }
}
