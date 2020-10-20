
using System;
using System.Collections.Generic;

namespace TCC.Candle.Data.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }


        public virtual ICollection<TaggedBook> Books { get; set; }
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

    }
}
