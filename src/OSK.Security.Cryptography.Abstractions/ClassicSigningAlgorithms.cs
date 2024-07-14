namespace OSK.Security.Cryptography.Abstractions
{
    public static class ClassicSigningAlgorithms
    {
        //
        // Summary:
        //     Gets a signing algorithm name that represents "MD5".
        //
        // Returns:
        //     A signing algorithm name that represents "MD5".
        public static CryptographicSigningAlgorithm MD5 { get; } = new CryptographicSigningAlgorithm("MD5");
        //
        // Summary:
        //     Gets a signing algorithm name that represents "SHA1".
        //
        // Returns:
        //     A signing algorithm name that represents "SHA1".
        public static CryptographicSigningAlgorithm SHA1 { get; } = new CryptographicSigningAlgorithm("SHA1");
        //
        // Summary:
        //     Gets a signing algorithm name that represents "SHA256".
        //
        // Returns:
        //     A signing algorithm name that represents "SHA256".
        public static CryptographicSigningAlgorithm SHA256 { get; } = new CryptographicSigningAlgorithm("SHA256");
        //
        // Summary:
        //     Gets a signing algorithm name that represents "SHA384".
        //
        // Returns:
        //     A signing algorithm name that represents "SHA384".
        public static CryptographicSigningAlgorithm SHA384 { get; } = new CryptographicSigningAlgorithm("SHA384");
        //
        // Summary:
        //     Gets a signing algorithm name that represents "SHA512".
        //
        // Returns:
        //     A signing algorithm name that represents "SHA512".
        public static CryptographicSigningAlgorithm SHA512 { get; } = new CryptographicSigningAlgorithm("SHA512");
    }
}
