using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Logic.Services.Abstract
{
    public interface IShelfService
    {
        /// <summary>
        /// Return the count of shelves in a library
        /// </summary>
        /// <param name="id">Library Id</param>
        /// <returns></returns>
        int GetShelvesCount(Guid libraryId);
        IEnumerable<Shelf> GetAllShelves(Guid libraryId);
        bool AddShelf(ShelfFormDto sfDto);
        bool DeleteShelf(Guid shelfId);
        bool EditShelf(ShelfFormDto sfDto);
        ShelfFormDto GetShelfById(Guid shelfId);
        bool Exists(Guid shelfId);
    }


}
