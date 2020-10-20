using System;
using System.Collections.Generic;

namespace TCC.Candle.Data.Entities
{
    public class Volume : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public Guid ShelfId { get; set; }
        public Shelf Shelf { get; set; }
    }
}
