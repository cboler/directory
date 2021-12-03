using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Models;
using PhoneDirectory.Providers;
using System.Collections.Generic;

namespace PhoneDirectory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectoryController : ControllerBase
    {
        private readonly ILogger<DirectoryController> _logger;
        private readonly IDirectoryEntryProvider _directoryEntryProvider;

        public DirectoryController(
            ILogger<DirectoryController> logger,
            IDirectoryEntryProvider directoryEntryProvider)
        {
            _logger = logger;
            _directoryEntryProvider = directoryEntryProvider;
        }

        [HttpGet("{queryString}")]
        public IEnumerable<DirectoryEntry> GetByName(string queryString)
        {
            return _directoryEntryProvider.GetDirectoryEntriesByName(queryString);
        }
    }
}
