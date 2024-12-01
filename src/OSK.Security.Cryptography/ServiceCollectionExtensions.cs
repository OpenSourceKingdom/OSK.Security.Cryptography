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
            => services.AddSymmetricKeyService <TCryptographicKeyService, TKeyInformation>(string.Empty);

        public static IServiceCollection AddSymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services,
            string algorithmName, bool isExperimental = false)
            where TCryptographicKeyService : SymmetricKeyService<TKeyInformation>
            where TKeyInformation : class, ISymmetricKeyInformation
        {
            services.TryAddTransient<SymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();
            return services.AddCryptographicKeyDescriptor(new CryptographicKeyDescriptor()
            {
                KeyAlgorithmName = algorithmName,
                KeyAlgorithmType = CryptographicKeyAlgorithmType.Symmetric,
                IsExperimental = isExperimental,
                KeyInformationType = typeof(TKeyInformation),
                KeyServiceType = typeof(SymmetricKeyService<TKeyInformation>)
            });
        }

        public static IServiceCollection AddAsymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services)
            where TCryptographicKeyService : AsymmetricKeyService<TKeyInformation>
            where TKeyInformation : class, IAsymmetricKeyInformation
            => services.AddAsymmetricKeyService<TCryptographicKeyService, TKeyInformation>(string.Empty);

        public static IServiceCollection AddAsymmetricKeyService<TCryptographicKeyService, TKeyInformation>(this IServiceCollection services, 
            string algorithmName, bool isExperimental = false)
            where TCryptographicKeyService : AsymmetricKeyService<TKeyInformation>
            where TKeyInformation : class, IAsymmetricKeyInformation
        {
            services.TryAddTransient<AsymmetricKeyService<TKeyInformation>, TCryptographicKeyService>();
            return services.AddCryptographicKeyDescriptor(new CryptographicKeyDescriptor()
            {
                KeyAlgorithmName = algorithmName,
                KeyAlgorithmType = CryptographicKeyAlgorithmType.Asymmetric,
                IsExperimental = isExperimental,
                KeyInformationType = typeof(TKeyInformation),
                KeyServiceType = typeof(AsymmetricKeyService<TKeyInformation>)
            });
        }

        public static IServiceCollection AddCryptographicKeyDescriptor(this IServiceCollection services, CryptographicKeyDescriptor keyDescriptor)
        {
            services.AddCryptography();
            services.TryAddTransient(keyDescriptor.KeyServiceType);

            services.AddSingleton(_ => keyDescriptor);

            return services;
        }
    }
}
