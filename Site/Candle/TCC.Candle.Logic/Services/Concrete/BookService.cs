using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories.Abstract;
using TCC.Candle.Logic.DataTransferObjects;
using TCC.Candle.Logic.Services.Abstract;

namespace TCC.Candle.Logic.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }
        public int GetBooksCount(Guid shelfId)
        {
            return _repo.GetBooksCount(shelfId);
        }

        public int GetLibraryBooksCount(Guid libraryId)
        {
            return _repo.GetLibraryBooksCount(libraryId);
        }

        public BookFormDto GetBookById(Guid bookId)
        {
            var book = _repo.GetById(bookId);
            if (book == null) return null;
            return new BookFormDto
            {
                Id = book.Id,
                Title = book.Title,
                SubTitle = book.SubTitle,
                Description = book.Description,
                ShelfId = book.ShelfId,
                ISBN13 = book.ISBN13,
                Pages = book.Pages,
                Released = book.Released,
                language = book.language
            };

        }

        public IEnumerable<Book> GetBooksOnShelf(Guid shelfId)
        {
            return _repo.Where(x => x.ShelfId == shelfId);
        }

        public IEnumerable<Book> GetAllBooks(Guid libraryId)
        {
            return _repo.Where(b => b.Shelf.LibraryId == libraryId);
        }

        public bool AddBook(BookFormDto bfDto)
        {
            var book = new Book()
            {
                Title = bfDto.Title,
                SubTitle = bfDto.SubTitle,
                Description = bfDto.Description,
                ISBN13 = bfDto.ISBN13,
                Modified = DateTime.Now,
                Pages = bfDto.Pages,
                ShelfId = bfDto.ShelfId,
                language = bfDto.language
            };
            return _repo.Add(book);
        }

        public bool DeleteBook(Guid bookId)
        {
            return _repo.Remove(bookId);
        }

        public bool EditBook(BookFormDto bfDto)
        {
            if (bfDto == null) return false;
            var book = new Book()
            {
                Id = bfDto.Id,
                Title = bfDto.Title,
                SubTitle = bfDto.SubTitle,
                Description = bfDto.Description,
                ISBN13 = bfDto.ISBN13,
                Modified = DateTime.Now,
                Pages = bfDto.Pages,
                ShelfId = bfDto.ShelfId,
                language = bfDto.language
            };
            return _repo.Update(bfDto.Id, book);
        }

        public bool Exists(Guid bookId)
        {
            return _repo.GetById(bookId) != null;
        }
    }
}
