using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;

namespace TCC.Candle.Data.Repositories.Concrete
{
    public class ShelfRepository : Repository<Shelf>, IShelfRepository
    {
        public ShelfRepository(IDesignTimeDbContextFactory<CandleContext> contextfactory) : base(contextfactory)
        {
        }

        public void LoadRelatedBooks(ref Shelf shelf)
        {
            context.Attach(shelf);
            context.Entry(shelf).Collection(s => s.Books).Load();
        }

        public int GetShelvesCount(Guid libraryId)
        {
            return context.Shelves.Count(s => s.LibraryId == libraryId);
        }
    }
}
