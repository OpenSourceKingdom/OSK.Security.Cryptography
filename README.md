# OSK.Security.Cryptography
This library is meant to help with making cryptography more accessible, usable, and, hopefully, easier to use and extend. By utilizing a set of generic
interfaces that defines common cryptographic security functions (encryption, decryption, signing, etc.), a user only needs to know the key information 
they want to use (Aes, Rsa, etc.) and can rely on the internal mechanisms to provide the necessary cryptographic key services that will handle the
security for the key. 

# Abstractions
The abstraction layer is meant to help provide a way to create different libraries that can handle and execute the core mechanisms for creating and handling
key services integrated with the library. An implementation for the abstractions is provided for this process, which should hopefully fulfill most needs. 
For any other libraries, `ICryptographicKeyServiceProvider` is meant to be the primary access point to the key services and should be implemented. Additionally,
the `CryptographicKeyDescriptor` is meant to describe key services and should also be implemented. `ICryptographicKeyService` and `ICryptographicKeyInformation`
implement the `IDisposable` interface and are meant to destroy any key and other sensitive data when destroyed. 

# Usage: Adding Cryptographic Algorithm integrations
Core to the internal logic is the `CryptographicKeyServiceProvider`, `CryptographicKeyService`, `SymmetricKeyService`, and `AsymmetricKeyService`
objects. When implementing new algorithms and using the standard logic, one of these three key service types must be used since the base `CryptographicKeyService`
exposes an internal method meant to help with initializing key information for a service. Additionally, the library utilizes dependency injection and it
is expected that integrations will use this approach with the library and will call one of the dependency injection extension methods (see the ServiceCollectionExtensions at the root of the logic library)
to add the necessary `CryptographicKeyDescriptor` used with the cryptographic key service provider. `ICryptographicKeyInformation` and `ICryptographicKeyService` should be considered sensitive and should be
setup to destroy the sensitive cryptographic data when disposed. Only `IPublicKeyInformation` data should be considered safe for public exposure.

Note: Individual implementations of the library can be standalone and may not require any of the above setup to be usable, however when being added to
dependency injection flows with this library as an integration, it is expected that the above mentioned conventions are followed.

# Usage: Consumers
Consumers should inject the core logic using the `AddCryptography` extension to ensure the necessary services for operation are added to the dependency contianer.
When wanting to utilize a cryptographic key service, users can call any of the methods on the `ICryptographicKeyServiceProvider` to get a key service that will handle encryption, 
and other cryptographic functions. After using these functions, users should dispose of the key service and key information as soon as they are able for security risk management.
Only the `IPublicKeyInformation` should be considered safe for public exposure. Users can then pick and choose the cryptographic services they need for their application by using 
an implementation that follows the stated conventions in the above integration subheading and adding it to the dependency container.


# Contributions and Issues
Any and all contributions are appreciated! Please be sure to follow the branch naming convention `OSK-{issue number}-{deliminated}-{branch}-{name}` as current workflows rely on it for automatic issue closure.
Please submit issues for discussion and tracking using the github issue tracker.