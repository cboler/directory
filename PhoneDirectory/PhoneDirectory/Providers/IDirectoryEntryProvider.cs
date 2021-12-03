using PhoneDirectory.Models;
using System.Collections.Generic;

namespace PhoneDirectory.Providers
{
    public interface IDirectoryEntryProvider
    {
        IEnumerable<DirectoryEntry> GetDirectoryEntriesByName(string name);
    }
}
