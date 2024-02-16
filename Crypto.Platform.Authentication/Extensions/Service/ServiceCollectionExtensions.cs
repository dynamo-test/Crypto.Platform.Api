using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Crypto.Platform.Authentication.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddAuthorizeLibrary(this IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}
