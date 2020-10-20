using System;

namespace TCC.Candle.Data.Entities
{
    public class BookAuthor : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public int Order { get; set; }


        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
