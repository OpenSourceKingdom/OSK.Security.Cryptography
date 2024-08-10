using System;
using System.Diagnostics.CodeAnalysis;

namespace OSK.Security.Cryptography.Abstractions
{
    public readonly struct CryptographicSigningAlgorithm : IEquatable<CryptographicSigningAlgorithm>
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

        #region IEquatable

        public bool Equals(CryptographicSigningAlgorithm other)
        {
            return string.Equals(AlgorithmName, other.AlgorithmName, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return AlgorithmName == null ? 0 : AlgorithmName.GetHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return obj is CryptographicSigningAlgorithm && Equals((CryptographicSigningAlgorithm)obj);
        }

        #endregion

        #region Operators

        public static bool operator ==(CryptographicSigningAlgorithm left, CryptographicSigningAlgorithm right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CryptographicSigningAlgorithm left, CryptographicSigningAlgorithm right)
        {
            return !(left == right);
        }

        #endregion
    }
}
