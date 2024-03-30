using OSK.Security.Cryptography.Abstractions;

namespace OSK.Security.Cryptography.UnitTests.Helpers
{
    public class UnregisteredKeyTestInformation : IAsymmetricKeyInformation, ISymmetricKeyInformation
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
