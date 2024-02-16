using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.Mappings;
using Crypto.Platform.Api.Swagger;
using Crypto.Platform.Api.UseCase.Class;
using Crypto.Platform.Api.UseCase.Interface;

namespace Crypto.Platform.Api.Extensions.Service
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            Type[] profiles = {
                typeof(FileUploadAutoMapperProfile),
                typeof(CryptoCurrencyAutoMapperProfile)
            };

            services.AddAutoMapper(profiles);

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IBaseUseCase<FileUploadResponse>, SetFileUploadedContent>();
            services.AddScoped<IBaseUseCase<IList<CryptoCurrencyResponse>>, GetAllCryptoCurrency>();
            services.AddScoped<IBaseUseCase<IList<ExchangeResponse>>, GetAllExchanges>();
            services.AddScoped<IBaseUseCase<ExchangeItemResponse>, GetExchangeById>();

            return services;
        }

        public static IServiceCollection AddSwaggerGenOptions(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
