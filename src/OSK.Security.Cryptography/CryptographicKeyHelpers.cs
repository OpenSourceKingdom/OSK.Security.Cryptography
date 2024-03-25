using OSK.Security.Cryptography.Exceptions;
using System.Linq;
using System.Security.Cryptography;

namespace OSK.Security.Cryptography
{
    public static class CryptographicKeyHelpers
    {
        public static void ValidateKeySize(int keySize, params KeySizes[] keySizes)
        {
            if (keySizes.All(keySizeLimit => keySize < keySizeLimit.MinSize || keySize > keySizeLimit.MaxSize ||
                  keySize % keySizeLimit.SkipSize != 0))
            {
                var messages = string.Join("\n", keySizes.Select(keySizeLimit => $"{keySizeLimit.MinSize} to {keySizeLimit.MaxSize} and be divisible by {keySizeLimit.SkipSize}"));
                throw new KeySizeException($"The provided key, {keySize}, was not valid. The keep must fit in any of the following key sizes:\n{messages}");
            }

            return;
        }
    }
}
