using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface ISymmetricKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation: ISymmetricKeyInformation
    {
    }
}
