using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// The core accessor to the cryptographic key algorithms. The provider is meant to retrieve and initialize key information for any key service requested
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerPointOfEntry)]
    public interface ICryptographicKeyServiceProvider
    {
        /// <summary>
        /// Retrieves a symmetric key service that can handle the symmetric key information provided.
        /// </summary>
        /// <typeparam name="TKeyInformation"><see cref="ISymmetricKeyInformation"/></typeparam>
        /// <param name="keyInformation">The symmetric that will be used to retrieve and initialize the symmetric key service</param>
        /// <returns>The symmetric key service that can handle the key information passed.</returns>
        ISymmetricKeyService<TKeyInformation> GetSymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, ISymmetricKeyInformation;

        /// <summary>
        /// Retrieves an asymmetric key service that can handle the asymmetric key information provided.
        /// </summary>
        /// <typeparam name="TKeyInformation"><see cref="IAsymmetricKeyInformation"/></typeparam>
        /// <param name="keyInformation">The asymmetric that will be used to retrieve and initialize the asymmetric key service</param>
        /// <returns>The asymmetric key service that can handle the key information passed.</returns>
        IAsymmetricKeyService<TKeyInformation> GetAsymmetricKeyService<TKeyInformation>(TKeyInformation keyInformation)
            where TKeyInformation : class, IAsymmetricKeyInformation;

        /// <summary>
        /// A generic accessor to a cryptographic key service, if a specific service type is not required for the consumer.
        /// </summary>
        /// <param name="keyInformation">Any <see cref="ICryptographicKeyInformation"/> that has been added to the dependency container to be used to retrieve and intiialize a key service that can handle the information.</param>
        /// <returns>A cryptographic key service that can handle the key information passed.</returns>
        ICryptographicKeyService GetKeyService(ICryptographicKeyInformation keyInformation);
    }
}
