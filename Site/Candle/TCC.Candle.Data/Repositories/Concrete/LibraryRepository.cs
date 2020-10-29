using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;

namespace TCC.Candle.Data.Repositories.Concrete
{
    public class LibraryRepository : Repository<Library>, ILibraryRepository
    {

        public LibraryRepository(IDesignTimeDbContextFactory<CandleContext> contextFactory) : base(contextFactory)
        {
        }

        public void LoadRelatedShelves(ref Library library)
        {
            context.Attach(library);
            context.Entry(library).Collection(l => l.Shelves).Load();
        }

        public void LoadRelatedBooks(ref Library library)
        {
            context.Attach(library);
            context.Entry(library).Collection(l => l.Shelves).Load();
            context.Entry(library).Collection(l => l.Shelves).Query().Select(s => s.Books).Load();
        }


    }
}
