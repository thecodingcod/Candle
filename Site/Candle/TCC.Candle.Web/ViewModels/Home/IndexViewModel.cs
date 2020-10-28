using System;
using System.Collections.Generic;

namespace TCC.Candle.Web.ViewModels.Home
{
    public class IndexViewModel
    {

        public int LibrariesCount { get; set; }
        public IEnumerable<IndexListItem> Libraries { get; set; }

    }

    public class IndexListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }

        // TODO: AddLibrary ImageUrl to the library model
        //public string ImageUrl { get; set; }
        public int ShelvesCount { get; set; }
        public int BooksCount { get; set; }
    }
}
