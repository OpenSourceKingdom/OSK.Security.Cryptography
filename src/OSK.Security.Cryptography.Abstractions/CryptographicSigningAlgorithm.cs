using System;

namespace OSK.Security.Cryptography.Abstractions
{
    public class CryptographicSigningAlgorithm
    {
        #region Variables

        public string AlgorithmName { get; }

        #endregion
        
        #region Constructors
        
        public CryptographicSigningAlgorithm(string algorithmName)
        {
            AlgorithmName = string.IsNullOrWhiteSpace(algorithmName)
                ? throw new ArgumentNullException(nameof(algorithmName))
                : algorithmName;
        }
        
        #endregion
    }
}
