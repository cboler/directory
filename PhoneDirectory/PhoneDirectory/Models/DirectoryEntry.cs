using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Models
{
    // todo: determine if it's really worth over-engineering the bejeezus out of this and having a Person entity etc. Spoiler:it isn't.
    public class DirectoryEntry
    {
        [Key]
        public int Id { get; set; }

        // todo: add validation attributes
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
