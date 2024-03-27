using Microsoft.Extensions.DependencyInjection;
using OSK.Security.Cryptography.Abstractions;
using System;

namespace OSK.Security.Cryptography.Internal.Services
{
    internal class CryptographicKeyServiceProvider : ICryptographicKeyServiceProvider
    {
        #region Variables

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructors

        public CryptographicKeyServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        #endregion

        #region ICryptographicKeyServiceProvider

        public IAsymmetricKeyService<TKeyInformation> GetAsymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation) 
            where TKeyInformation : class, IAsymmetricKeyInformation
        {
            var keyService = _serviceProvider.GetRequiredService<AsymmetricKeyService<TKeyInformation>>();
            keyService.KeyInformation = keyInformation;

            return keyService;
        }

        public ISymmetricKeyService<TKeyInformation> GetSymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, ISymmetricKeyInformation
        {
            var keyService = _serviceProvider.GetRequiredService<SymmetricKeyService<TKeyInformation>>();
            keyService.KeyInformation = keyInformation;

            return keyService;
        }

        #endregion
    }
}
