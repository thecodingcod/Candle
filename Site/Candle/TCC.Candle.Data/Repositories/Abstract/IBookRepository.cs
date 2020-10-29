using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Repositories.Abstract
{
    public interface IBookRepository : IRepository<Book>
    {
        int GetBooksCount(Guid shelfId);
        int GetLibraryBooksCount(Guid libraryId);



    }
}
