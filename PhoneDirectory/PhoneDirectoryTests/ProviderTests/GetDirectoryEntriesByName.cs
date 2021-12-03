using AutoFixture;
using FluentAssertions;
using PhoneDirectory.Models;
using Xunit;

namespace PhoneDirectoryTests.ProviderTests
{
    public class GetDirectoryEntriesByName : DirectoryEntryProviderTestBase
    {
        [Fact]
        public void DirectoryEntryProvider_GetDirectoryEntriesByName_Success()
        {
            // Arrange
            var expected = AutoFixture.CreateMany<DirectoryEntry>();

            // TODO: I'm querying the data with linq... not sure how to mock that tbh, it's not worth the time
            // could switch to using find or findAsync for scalability
            //MockDirectoryContext.Setup(x => x.DirectoryEntries.)

            // Act
            var actual = DirectoryEntryProvider.GetDirectoryEntriesByName("J");

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
