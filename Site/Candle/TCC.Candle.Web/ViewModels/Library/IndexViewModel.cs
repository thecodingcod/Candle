using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Candle.Web.ViewModels.Library
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ShelvesCount { get; set; }
        public IEnumerable<ShelveListItem> Shelves { get; set; }

    }

    public class ShelveListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int BooksCount { get; set; }
        public IEnumerable<BookListItem> Books { get; set; }
    }

    public class BookListItem
    {
        public Guid Id { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
