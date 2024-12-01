using System;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// Describes a cryptographic key implementation for the library
    /// </summary>
    public class CryptographicKeyDescriptor
    {
        /// <summary>
        /// The name of the cryptographic algorithm, for display and/or debug purposes
        /// </summary>
        public string KeyAlgorithmName { get; set; }

        public CryptographicKeyAlgorithmType KeyAlgorithmType { get; set; }

        /// <summary>
        /// The algorithm is currently in development and should not be considered a practical cryptographic implmentation for sensitive information
        /// </summary>
        public bool IsExperimental { get; set; }

        /// <summary>
        /// The type of key information this algorithm utilizes
        /// </summary>
        public Type KeyInformationType { get; set; }

        /// <summary>
        /// The type of key service that handles the designated key information
        /// </summary>
        public Type KeyServiceType { get; set; }
    }
}
