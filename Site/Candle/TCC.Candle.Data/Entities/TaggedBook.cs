using System;

namespace TCC.Candle.Data.Entities
{
    // Suggestion: Merge TaggedItem and ShelvedItem into ConnectedItem, add ConnectionType flag 0- Shelf, 1- Tag
    public class TaggedBook : BaseEntity
    {
        public Guid? BookId { get; set; }
        public Guid? TagId { get; set; }
        public int Order { get; set; }

        public Book Book { get; set; }
        public Tag Tag { get; set; }
    }
}
