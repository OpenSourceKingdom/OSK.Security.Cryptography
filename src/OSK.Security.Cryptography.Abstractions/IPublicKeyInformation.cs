using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// Represents key information that is meant to be public in order for cryptographic parameters to be shared.
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationRequired)]
    public interface IPublicKeyInformation
    {
    }
}
