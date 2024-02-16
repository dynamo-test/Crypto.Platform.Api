using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Crypto.Platform.Infrastructure.Patterns.Repository.Class;
using Crypto.Platform.Infrastructure.Patterns.Repository.Interface;
using Crypto.Platform.Infrastructure.Context.Interface;
using Crypto.Platform.Infrastructure.Context.Class;

namespace Crypto.Platform.Infrastructure.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IContext<>), typeof(Context<>));

            return services;
        }

        public static IServiceCollection AddRepositoryPattern(this IServiceCollection services)
        {
            services.AddScoped<IContentRepository, ContentRepository>();

            return services;
        }
    }
}
