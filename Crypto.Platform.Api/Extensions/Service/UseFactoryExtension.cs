using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Crypto.Platform.Api.Extensions.Factories;

namespace Crypto.Platform.Api.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class UseFactoryExtension
    {
        public static void UseFactory(this WebApplication app)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            FileUploadFactory.Configure(app.Services.GetService<IMapper>());
            CryptoCurrencyFactory.Configure(app.Services.GetService<IMapper>());
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
