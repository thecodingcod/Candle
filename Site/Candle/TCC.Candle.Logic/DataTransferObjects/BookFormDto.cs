using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Enums;

namespace TCC.Candle.Logic.DataTransferObjects
{
    public class BookFormDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ISBN13 { get; set; }
        public int Pages { get; set; }
        public DateTime Released { get; set; }
        public Languages language { get; set; }

        public string Author { get; set; }


        // Navigational Properties
        public Guid ShelfId { get; set; }
    }


    // TODO: Support Adding Authors
    // TODO: Support Adding Reviews
    // TODO: Support Adding Tags
}
