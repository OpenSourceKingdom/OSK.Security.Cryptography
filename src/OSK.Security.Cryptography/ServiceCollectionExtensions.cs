using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services)
            where TCryptographicKeyService : SymmetricKeyService<TKeyInformation>
            where TKeyInformation : SymmetricKeyInformation
        {
            services.TryAddTransient<SymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();

            return services;
        }

        public static IServiceCollection AddAsymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services)
            where TCryptographicKeyService : AsymmetricKeyService<TKeyInformation>
            where TKeyInformation : AsymmetricKeyInformation
        {
            services.TryAddTransient<AsymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();

            return services;
        }

    }
}
