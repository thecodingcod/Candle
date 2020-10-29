using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Repositories.Abstract
{
    public interface IShelfRepository : IRepository<Shelf>
    {
        void LoadRelatedBooks(ref Shelf shelf);
        int GetShelvesCount(Guid libraryId);
    }
}
