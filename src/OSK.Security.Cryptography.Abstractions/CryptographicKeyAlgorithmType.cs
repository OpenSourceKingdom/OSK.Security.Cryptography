namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// Represents the type of algorithm that a cryptographic key service utilizes 
    /// </summary>
    public enum CryptographicKeyAlgorithmType
    {
        /// <summary>
        /// An algorithm that utilizes a single key to perform cryptography
        /// </summary>
        Symmetric,
        /// <summary>
        /// An algorithm that utilizes a private and public key pair to perform cryptography
        /// </summary>
        Asymmetric,
        /// <summary>
        /// The algorithm has an unspecified algorithm type. This could be for development/experimental purposes, or simply was not designated in the implementation.
        /// </summary>
        Unspecified
    }
}
