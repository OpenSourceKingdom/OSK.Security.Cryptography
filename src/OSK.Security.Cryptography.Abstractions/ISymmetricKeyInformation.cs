using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// A set of key information specific to symmetric cryptographic algorithms
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationRequired)]
    public interface ISymmetricKeyInformation : ICryptographicKeyInformation
    {
    }
}
