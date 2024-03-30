using OSK.Security.Cryptography.Models;

namespace OSK.Security.Cryptography.UnitTests.Helpers
{
    public class AsymmetricKeyTestInformation : AsymmetricKeyInformation<PublicKeyInformation>
    {
        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override PublicKeyInformation GetPublicKeyInformation()
        {
            throw new NotImplementedException();
        }
    }
}
