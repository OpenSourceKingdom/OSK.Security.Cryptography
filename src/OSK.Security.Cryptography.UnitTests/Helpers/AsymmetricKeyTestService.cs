using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography.UnitTests.Helpers
{
    public class AsymmetricKeyTestService : AsymmetricKeyService<AsymmetricKeyTestInformation>
    {
        public override ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<byte[]> SignAsync(byte[] data, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, CryptographicSigningAlgorithm signingAlgorithm, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
