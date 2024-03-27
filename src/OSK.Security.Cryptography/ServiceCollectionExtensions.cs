using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Security.Cryptography.Abstractions;
using OSK.Security.Cryptography.Internal.Services;

namespace OSK.Security.Cryptography
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCryptography(this IServiceCollection services)
        {
            services.TryAddTransient<ICryptographicKeyServiceProvider, CryptographicKeyServiceProvider>();

            return services;
        }

        public static IServiceCollection AddSymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services)
            where TCryptographicKeyService : SymmetricKeyService<TKeyInformation>
            where TKeyInformation : class, ISymmetricKeyInformation
        {
            services.AddCryptography();
            services.TryAddTransient<SymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();

            return services;
        }

        public static IServiceCollection AddAsymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services)
            where TCryptographicKeyService : AsymmetricKeyService<TKeyInformation>
            where TKeyInformation : class, IAsymmetricKeyInformation
        {
            services.AddCryptography();
            services.TryAddTransient<AsymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();

            return services;
        }

    }
}
