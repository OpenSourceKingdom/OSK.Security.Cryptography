using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationRequired)]
    public interface ISymmetricKeyService<TKeyInformation> : ICryptographicKeyService<TKeyInformation>
        where TKeyInformation: ISymmetricKeyInformation
    {
    }
}
