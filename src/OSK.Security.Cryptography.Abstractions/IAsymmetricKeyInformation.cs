using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    /// <summary>
    /// A set of key information specific to asymmetric cryptographic algorithms
    /// </summary>
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface IAsymmetricKeyInformation : ICryptographicKeyInformation
    {
    }
}
