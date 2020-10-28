using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Repositories.Abstract
{
    public interface ILibraryRepository : IRepository<Library>
    {
        void LoadRelatedShelves(ref Library library);
        void LoadRelatedBooks(ref Library library);

    }
}
