using System;
using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationRequired)]
    public interface ICryptographicKeyInformation : IDisposable
    {
    }
}
