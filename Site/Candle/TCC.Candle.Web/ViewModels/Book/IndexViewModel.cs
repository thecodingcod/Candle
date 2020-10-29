using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Candle.Web.ViewModels.Book
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string ISBN13 { get; set; }
        public string Author { get; set; }
        //public string ImageUrl { get; set; }

        // TODO: Add Tag list
        // TODO: Add Review list
        // TODO: Add Rates

        // Navigation Props
        public string Shelf { get; set; }
        public Guid ShelfId { get; set; }
        public string Library { get; set; }
        public Guid LibraryId { get; set; }
    }
}
