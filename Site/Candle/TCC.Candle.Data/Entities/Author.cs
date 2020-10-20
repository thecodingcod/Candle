
using System;
using System.Collections.Generic;

namespace TCC.Candle.Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ImgUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }



        public virtual ICollection<BookAuthor> Books { get; set; }
    }
}
