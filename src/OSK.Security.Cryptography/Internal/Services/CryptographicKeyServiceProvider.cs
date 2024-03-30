using Microsoft.Extensions.DependencyInjection;
using OSK.Security.Cryptography.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (keyInformation == null)
            {
                throw new ArgumentNullException(nameof(keyInformation));
            }

            var keyService = _serviceProvider.GetRequiredService<AsymmetricKeyService<TKeyInformation>>();
            keyService.KeyInformation = keyInformation;

            return keyService;
        }

        public ISymmetricKeyService<TKeyInformation> GetSymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, ISymmetricKeyInformation
        {
            if (keyInformation == null)
            {
                throw new ArgumentNullException(nameof(keyInformation));
            }

            var keyService = _serviceProvider.GetRequiredService<SymmetricKeyService<TKeyInformation>>();
            keyService.KeyInformation = keyInformation;

            return keyService;
        }

        public ICryptographicKeyService GetKeyService(ICryptographicKeyInformation keyInformation)
        {
            if (keyInformation == null)
            {
                throw new ArgumentNullException(nameof(keyInformation));
            }

            var keyServices = _serviceProvider.GetRequiredService<IEnumerable<ICryptographicKeyService>>();
            var selectedKeyService = keyServices.FirstOrDefault(keyService => keyService.TrySetKeyInformation(keyInformation));
            if (selectedKeyService == null)
            {
                throw new InvalidOperationException($"No registered cryptographic key service could handle key information of type {keyInformation.GetType()}. Are you missing a dependency injection?");
            }

            return selectedKeyService;
        }

        #endregion
    }
}
