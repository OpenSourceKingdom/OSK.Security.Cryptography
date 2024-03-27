namespace OSK.Security.Cryptography.Abstractions
{
    public interface ICryptographicKeyInformation<TPublicKeyInformation>: ICryptographicKeyInformation
        where TPublicKeyInformation : IPublicKeyInformation
    {
        public TPublicKeyInformation GetPublicKeyInformation();
    }
}
