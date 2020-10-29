using System;
using System.Collections.Generic;

namespace TCC.Candle.Data.Entities
{
    public class Shelf : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; } //hex value


        // Navigational Properties
        public virtual ICollection<Book> Books { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

    }
}
