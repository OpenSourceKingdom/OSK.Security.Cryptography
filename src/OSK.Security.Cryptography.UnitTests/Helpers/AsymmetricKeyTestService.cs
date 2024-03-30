using System.Security.Cryptography;

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

        public override ValueTask<byte[]> SignAsync(byte[] data, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<bool> ValidateSignatureAsync(byte[] data, byte[] signedData, HashAlgorithmName hashAlgorithmName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
