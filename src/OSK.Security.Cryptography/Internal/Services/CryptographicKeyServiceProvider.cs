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

            var keyDescriptors = _serviceProvider.GetRequiredService<IEnumerable<CryptographicKeyDescriptor>>();
            var keyType = keyInformation.GetType();
            var selectedKeyDescriptor = keyDescriptors.FirstOrDefault(descriptor => descriptor.KeyInformationType == keyType);
            if (selectedKeyDescriptor == null)
            {
                throw new InvalidOperationException($"No registered cryptographic key service could handle key information of type {keyType.FullName}. Are you missing a dependency injection?");
            }

            var keyService = (ICryptographicKeyService)_serviceProvider.GetService(selectedKeyDescriptor.KeyServiceType);
            if (keyService is CryptographicKeyService cryptographicKeyService && !cryptographicKeyService.TrySetKeyInformation(keyInformation))
            {
                throw new InvalidOperationException($"An unexpected error occurred when attempting to set the key information, of type {keyType.FullName}, to the key service, of type {selectedKeyDescriptor.KeyServiceType.FullName}.");
            }

            return keyService;
        }

        #endregion
    }
}
