namespace OSK.Security.Cryptography.UnitTests.Helpers
{
    public class SymmetricKeyTestService : SymmetricKeyService<SymmetricKeyTestInformation>
    {
        public override ValueTask<byte[]> DecryptAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<byte[]> EncryptAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
