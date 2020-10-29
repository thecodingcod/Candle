using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;

namespace TCC.Candle.Data.Repositories.Concrete
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IDesignTimeDbContextFactory<CandleContext> contextfactory) : base(contextfactory)
        {
        }

        public int GetBooksCount(Guid shelfId)
        {
            return context.Books.Count(b => b.ShelfId == shelfId);
        }

        public int GetLibraryBooksCount(Guid libraryId)
        {
            var lib = context.Libraries.SingleOrDefault(l => l.Id == libraryId);
            if (lib == null) return 0;

            // load shelves and thier related books
            context.Entry(lib).Collection(l => l.Shelves).Load();
            context.Entry(lib).Collection(l => l.Shelves).Query().Include(s => s.Books).Load();

            return lib.Shelves.SelectMany(s => s.Books).Count();
        }
    }
}
