using System;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories;

namespace TCC.Candle.Logic
{
    public class BookService : IBookService
    {
        private IRepository<Book> repo;
        public BookService(IRepository<Book> repo)
        {
            this.repo = repo;
        }
        public string GetBookName(Guid Id)
        {
            var book = repo.GetSingle(b => b.Id == Id);
            return book.Title;
        }
    }
}
