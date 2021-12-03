using AutoFixture;
using Moq;
using PhoneDirectory.Models;
using PhoneDirectory.Providers;

namespace PhoneDirectoryTests.ProviderTests
{
    public abstract class DirectoryEntryProviderTestBase
    {
        internal Fixture AutoFixture;
        internal Mock<DirectoryContext> MockDirectoryContext;
        internal IDirectoryEntryProvider DirectoryEntryProvider;

        protected DirectoryEntryProviderTestBase()
        {
            AutoFixture = new Fixture();
            MockDirectoryContext = new Mock<DirectoryContext>();

            DirectoryEntryProvider = new DirectoryEntryProvider(MockDirectoryContext.Object);
        }
    }
}
