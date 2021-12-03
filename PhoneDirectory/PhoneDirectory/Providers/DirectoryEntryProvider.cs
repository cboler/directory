using PhoneDirectory.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhoneDirectory.Providers
{
    public class DirectoryEntryProvider : IDirectoryEntryProvider
    {
        private readonly DirectoryContext _directoryContext;

        public DirectoryEntryProvider(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        public IEnumerable<DirectoryEntry> GetDirectoryEntriesByName(string name)
        {
            return _directoryContext.DirectoryEntries.Where(x => x.Name.Contains(name));
        }
    }
}
