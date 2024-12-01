using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// A set of key information that is used to initialize a key service. The data in this key is considered to a mix of sensitive and public key data 
    /// and should not be shared. If key informations should be shared, please use <see cref="GetPublicKeyInformation"/>
    /// </summary>
    /// <typeparam name="TPublicKeyInformation">The type of public key information that is used to initialize the associated cryptographic key service</typeparam>
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface ICryptographicKeyInformation<TPublicKeyInformation>: ICryptographicKeyInformation
        where TPublicKeyInformation : IPublicKeyInformation
    {
        /// <summary>
        /// An accessor to getting publicly shareable key information for initializing cryptographic key algorithms
        /// </summary>
        /// <returns>Specific key information that is considered shareable to the public and will not risk revealing sensitive data encrypted by
        /// the associated cryptographic key service</returns>
        public TPublicKeyInformation GetPublicKeyInformation();
    }
}
