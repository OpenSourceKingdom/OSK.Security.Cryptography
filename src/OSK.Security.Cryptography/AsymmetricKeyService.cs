using OSK.Security.Cryptography.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OSK.Security.Cryptography
{
    public abstract class AsymmetricKeyService<TKeyInformation> : CryptographicKeyService<TKeyInformation>, IAsymmetricKeyService<TKeyInformation>
        where TKeyInformation : class, IAsymmetricKeyInformation
    {
        #region Variables

        public virtual IEnumerable<CryptographicSigningAlgorithm> SupportedSigningAlgorithms { get; } = Enumerable.Empty<CryptographicSigningAlgorithm>();

        #endregion

        #region IAsymmetricKey

        public abstract ValueTask<byte[]> SignAsync(byte[] data, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default);
        public abstract ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default);

        #endregion

        #region

        protected void ValidateSigningAlgorithmSupport(CryptographicSigningAlgorithm signingAlgorithm)
        {
            if (signingAlgorithm == null)
            {
                throw new ArgumentNullException(nameof(signingAlgorithm));
            }
            // No specific signing algorithms set, so we'll let the consumer determine how to handle this
            if (!SupportedSigningAlgorithms.Any())
            {
                return;
            }

            var supportedAlgorithm = SupportedSigningAlgorithms.FirstOrDefault(alg => alg.AlgorithmName.Equals(signingAlgorithm.AlgorithmName, StringComparison.OrdinalIgnoreCase));
            if (supportedAlgorithm == null)
            {
                throw new ArgumentException($"The specified signing algorithm, {signingAlgorithm.AlgorithmName}, is not supported by key service of type {GetType().FullName}." +
                    $" Please use any of the support algorithms: [{string.Join(", ", SupportedSigningAlgorithms.Select(a => a.AlgorithmName))}]");
            }
        }

        #endregion
    }
}
