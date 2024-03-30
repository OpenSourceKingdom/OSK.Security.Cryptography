using Microsoft.Extensions.DependencyInjection;
using OSK.Security.Cryptography.Abstractions;
using OSK.Security.Cryptography.UnitTests.Helpers;
using Xunit;

namespace OSK.Security.Cryptography.UnitTests.Internal.Services
{
    public class CryptographicKeyServiceProviderUnitTests
    {
        #region Variables

        private readonly ICryptographicKeyServiceProvider _keyServiceProvider;

        #endregion

        #region Constructors

        public CryptographicKeyServiceProviderUnitTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAsymmetricKeyService<AsymmetricKeyTestService, AsymmetricKeyTestInformation>();
            serviceCollection.AddSymmetricKeyService<SymmetricKeyTestService, SymmetricKeyTestInformation>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            _keyServiceProvider = serviceProvider.GetRequiredService<ICryptographicKeyServiceProvider>();
        }

        #endregion

        #region GetAsymmetricKeyService

        [Fact]
        public void GetAsymmetricKeyService_NullKeyInformation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            Assert.Throws<ArgumentNullException>(() => _keyServiceProvider.GetAsymmetricKeyService<AsymmetricKeyTestInformation>(null));
        }

        [Fact]
        public void GetAsymmetricKeyService_UnregisteredKeyInformation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            Assert.Throws<InvalidOperationException>(() => _keyServiceProvider.GetAsymmetricKeyService(new UnregisteredKeyTestInformation()));
        }

        [Fact]
        public void GetAsymmetricKeyService_ValidKeyInformation_ReturnsSuccessfully()
        {
            // Arrange
            var testInformation = new AsymmetricKeyTestInformation();

            // Act
            var keyService = _keyServiceProvider.GetAsymmetricKeyService(testInformation);

            // Assert
            Assert.NotNull(keyService);
            Assert.Equal(testInformation, keyService.KeyInformation);
        }

        #endregion

        #region GetSymmetricKeyService

        [Fact]
        public void GetSymmetricKeyService_NullKeyInformation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            Assert.Throws<ArgumentNullException>(() => _keyServiceProvider.GetSymmetricKeyService<SymmetricKeyTestInformation>(null));
        }

        [Fact]
        public void GetSymmetricKeyService_UnregisteredKeyInformation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            Assert.Throws<InvalidOperationException>(() => _keyServiceProvider.GetSymmetricKeyService(new UnregisteredKeyTestInformation()));
        }

        [Fact]
        public void GetSsymmetricKeyService_ValidKeyInformation_ReturnsSuccessfully()
        {
            // Arrange
            var testInformation = new SymmetricKeyTestInformation();

            // Act
            var keyService = _keyServiceProvider.GetSymmetricKeyService(testInformation);

            // Assert
            Assert.NotNull(keyService);
            Assert.Equal(testInformation, keyService.KeyInformation);
        }

        #endregion

        #region GetKeyService

        [Fact]
        public void GetKeyService_NullKeyInformation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            Assert.Throws<ArgumentNullException>(() => _keyServiceProvider.GetKeyService(null));
        }

        [Fact]
        public void GetKeyService_UnregisteredKeyInformation_ThrowsInvalidOperationException()
        {
            // Arrange/Act/Assert
            Assert.Throws<InvalidOperationException>(() => _keyServiceProvider.GetKeyService(new UnregisteredKeyTestInformation()));
        }

        [Fact]
        public void GetKeyService_GenericKeyInformation_ReturnsService()
        {
            // Arrange
            var testInformation = new AsymmetricKeyTestInformation();
            var testInformation2 = new SymmetricKeyTestInformation();

            // Act
            var service1 = _keyServiceProvider.GetKeyService(testInformation);
            var service2 = _keyServiceProvider.GetKeyService(testInformation2);

            // Assert
            Assert.NotNull(service1);
            Assert.IsType<AsymmetricKeyTestService>(service1);


            Assert.NotNull(service2);
            Assert.IsType<SymmetricKeyTestService>(service2);
        }

        #endregion
    }
}
