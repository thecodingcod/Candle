using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Candle.Logic.DataTransferObjects
{
    public class ShelfFormDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public Guid LibraryId { get; set; }
    }
}
