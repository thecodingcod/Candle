using System;

namespace TCC.Candle.Data.Entities
{
    public class Review : BaseEntity
    {
        public string Content { get; set; }
        public Rates Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        // Navigational Property
        public Guid BookId { get; set; }
        public Book Book { get; set; }

    }
}
