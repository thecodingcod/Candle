using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Candle.Web.ViewModels.Shelf
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BooksCount { get; set; }
        public IEnumerable<BookItem> Books { get; set; }
    }

    public class BookItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        //public IEnumerable<TagItem> Tags { get; set; }
    }

    public class TagItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
