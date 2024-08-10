using Xunit;

namespace OSK.Security.Cryptography.Abstractions.UnitTests
{
    public class CryptographicSigningAlgorithmTests
    {
        #region Equals

        [Theory]
        [InlineData("World", "Hello")]
        [InlineData("world", "World")]
        public void Equals_ObjectsNotEqual_ReturnsFalse(string algName1, string algName2)
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm(algName1);
            var algorithm2 = new CryptographicSigningAlgorithm(algName2);

            // Act
            var result = algorithm1 == algorithm2;
            var result2 = algorithm1.Equals(algorithm2);

            // Assert
            Assert.False(result);
            Assert.False(result2);
        }

        [Fact]
        public void Equals_DefaultObjectDoesNotEqualCustomObject_ReturnsFalse()
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm();
            var algorithm2 = new CryptographicSigningAlgorithm("alg");

            // Act
            var result = algorithm1 == algorithm2;
            var result2 = algorithm1.Equals(algorithm2);

            // Assert
            Assert.False(result);
            Assert.False(result2);
        }

        [Fact]
        public void Equals_ObjectsEqual_ReturnsTrue()
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm("Hello");
            var algorithm2 = new CryptographicSigningAlgorithm("Hello");

            // Act
            var result = algorithm1 == algorithm2;
            var result2 = algorithm1.Equals(algorithm2);

            // Assert
            Assert.True(result);
            Assert.True(result2);
        }

        [Fact]
        public void Equals_DefaultObjectsEqual_ReturnsTrue()
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm();
            var algorithm2 = new CryptographicSigningAlgorithm();

            // Act
            var result = algorithm1 == algorithm2;
            var result2 = algorithm1.Equals(algorithm2);

            // Assert
            Assert.True(result);
            Assert.True(result2);
        }

        #endregion

        #region DoesNotEqual Operator

        [Fact]
        public void DoesNotEqualOperator_ObjectsEqual_ReturnsFalse()
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm();
            var algorithm2 = new CryptographicSigningAlgorithm();

            // Act
            var result = algorithm1 != algorithm2;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DoesNotEqualOperator_ObjectsDoNotEqual_ReturnsTrue()
        {
            // Arrange
            var algorithm1 = new CryptographicSigningAlgorithm("Hello");
            var algorithm2 = new CryptographicSigningAlgorithm();

            // Act
            var result = algorithm1 != algorithm2;

            // Assert
            Assert.True(result);
        }

        #endregion
    }
}
