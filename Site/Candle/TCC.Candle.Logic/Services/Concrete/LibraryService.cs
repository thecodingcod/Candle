using System;
using System.Collections.Generic;
using System.Linq;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;
using TCC.Candle.Logic.DataTransferObjects;
using TCC.Candle.Logic.Services.Abstract;
namespace TCC.Candle.Logic.Services.Concrete
{
    public class LibraryService : ILibraryService
    {
        private ILibraryRepository repo;
        public LibraryService(ILibraryRepository libraries)
        {
            repo = libraries;
        }


        public LibraryFormDto GetById(Guid id)
        {
            var item = repo.GetById(id);
            if (item == null) return null;
            return new LibraryFormDto()
            {
                Title = item.Title,
                Description = item.Description,
                ImageUrl = item.ImageUrl
            };
        }
        public IEnumerable<Library> GetAllLibraries()
        {
            return repo.GetAll();
        }
        public int GetLibrariesCount()
        {
            return repo.GetAll().Count();
        }
        public int GetLibraryBooksCount(Guid Id)
        {
            var lib = repo.GetById(Id);
            if (lib == null) return 0;
            repo.LoadRelatedBooks(ref lib);
            return lib.Shelves.Sum(i => i.Books.Count());
        }
        public int GetLibraryShelvesCount(Guid Id)
        {
            var lib = repo.GetById(Id);
            if (lib == null) return 0;
            repo.LoadRelatedShelves(ref lib);
            return lib.Shelves.Count;
        }



        public bool AddLibrary(LibraryFormDto libraryFormDto)
        {
            // TODO: AddLibrary validation procedure later (for now rely on the presentation validation)
            if (libraryFormDto == null) return false;
            var lib = new Library
            {
                Title = libraryFormDto.Title,
                Description = libraryFormDto.Description,
                Modified = DateTime.Now
            };
            return repo.Add(lib);
        }
        public bool EditLibrary(Guid Id, LibraryFormDto libraryFormDto)
        {
            if (libraryFormDto == null) return false;
            var result = repo.Update(Id, new Library()
            {
                Id = Id,
                Title = libraryFormDto.Title,
                Description = libraryFormDto.Description,
                Modified = DateTime.Now
            });
            return result;
        }

        public bool DeleteLibrary(Guid Id)
        {
            return repo.Remove(Id);
        }


    }
}
