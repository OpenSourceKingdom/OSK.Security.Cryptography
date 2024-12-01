using System;
using OSK.Hexagonal.MetaData;

namespace OSK.Security.Cryptography.Abstractions
{
    [HexagonalPort(HexagonalPort.Secondary)]
    public interface ICryptographicKeyInformation : IDisposable
    {
    }
}
