using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;
using TCC.Candle.Logic.DataTransferObjects;
using TCC.Candle.Logic.Services.Abstract;

namespace TCC.Candle.Logic.Services.Concrete
{
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _repo;
        public ShelfService(IShelfRepository repo) => _repo = repo;
        public int GetShelvesCount(Guid libraryId)
        {
            return _repo.GetShelvesCount(libraryId);
        }
        public IEnumerable<Shelf> GetAllShelves(Guid libraryId)
        {
            return _repo.Where(s => s.LibraryId == libraryId);
        }
        public bool AddShelf(ShelfFormDto sfDto)
        {
            if (sfDto is null) return false;
            var shelf = new Shelf
            {
                Title = sfDto.Title,
                Description = sfDto.Description,
                Color = sfDto.Color,
                LibraryId = sfDto.LibraryId,
            };
            return _repo.Add(shelf);
        }
        public bool DeleteShelf(Guid shelfId)
        {
            var shelf = _repo.GetSingle(s => s.Id == shelfId);
            if (shelf == null) return false;
            return _repo.Remove(shelf.Id);
        }

        public bool EditShelf(ShelfFormDto sfDto)
        {
            if (sfDto is null) return false;
            var shelf = new Shelf
            {
                Id = sfDto.Id,
                Title = sfDto.Title,
                Description = sfDto.Description,
                Color = sfDto.Color,
                LibraryId = sfDto.LibraryId,
            };
            return _repo.Update(sfDto.Id, shelf);
        }

        public ShelfFormDto GetShelfById(Guid shelfId)
        {
            var item = _repo.GetById(shelfId);
            if (item == null) return null;
            var sfdto = new ShelfFormDto
            {
                Id = item.Id,
                LibraryId = item.LibraryId,
                Description = item.Description,
                Color = item.Color,
                Title = item.Title
            };
            return sfdto;
        }

        public bool Exists(Guid shelfId)
        {
            return _repo.GetById(shelfId) != null;
        }
    }
}
