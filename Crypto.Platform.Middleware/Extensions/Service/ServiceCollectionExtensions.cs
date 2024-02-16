using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Crypto.Platform.Middleware.Patterns.Proxy.Class;
using Crypto.Platform.Middleware.Patterns.Proxy.Interface;
using Crypto.Platform.Middleware.Mappings;

namespace Crypto.Platform.Middleware.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMiddlewareAutoMapperProfiles(this IServiceCollection services)
        {
            Type[] profiles = {
                typeof(MetaDataAutoMapperProfile),
                typeof(CryptoCurrencyAutoMapperProfile),
                typeof(ContentEntityAutoMapperProfile)
            };

            services.AddAutoMapper(profiles);

            return services;
        }
        public static IServiceCollection AddProxyPattern(this IServiceCollection services)
        {
            services.AddScoped<IFileUploadProxy, FileUploadProxy>();
            services.AddScoped<ICryptoCurrencyProxy, CryptoCurrencyProxy>();

            return services;
        }
    }
}
