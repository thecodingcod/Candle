using System;
using System.Collections.Generic;
using TCC.Candle.Data.Enums;

namespace TCC.Candle.Data.Entities
{

    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ISBN13 { get; set; }
        public int Pages { get; set; }
        public DateTime Released { get; set; }
        public Languages language { get; set; }
        public string ImgUrl { get; set; }


        // Navigational Properties
        public Guid ShelfId { get; set; }
        public Shelf Shelf { get; set; }

        public Guid? VolumeId { get; set; }
        public Volume Volume { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<TaggedBook> Tags { get; set; }
        public virtual ICollection<BookAuthor> Authors { get; set; }
    }
}
