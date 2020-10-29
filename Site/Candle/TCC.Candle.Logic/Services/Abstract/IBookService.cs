using System;
using System.Collections.Generic;
using System.Text;
using TCC.Candle.Data.Entities;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Logic.Services.Abstract
{
    public interface IBookService
    {
        int GetBooksCount(Guid shelfId);

        /// <summary>
        /// Return the count of books in a Library
        /// </summary>
        /// <param name="libraryId">Library Id</param>
        /// <returns></returns>
        int GetLibraryBooksCount(Guid libraryId);

        /// <summary>
        /// Get Book info using it's ID
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        BookFormDto GetBookById(Guid bookId);

        /// <summary>
        /// Get all books on certain shelf
        /// </summary>
        /// <param name="shelfId">target shelf Id</param>
        /// <returns></returns>
        IEnumerable<Book> GetBooksOnShelf(Guid shelfId);

        /// <summary>
        /// Get all book in a library
        /// </summary>
        /// <param name="libraryId">target library id</param>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks(Guid libraryId);

        /// <summary>
        /// Add a book
        /// </summary>
        /// <param name="bfDto"></param>
        /// <returns></returns>
        bool AddBook(BookFormDto bfDto);

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        bool DeleteBook(Guid bookId);

        /// <summary>
        /// Edit Certain Books
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="bfDto"></param>
        /// <returns></returns>
        bool EditBook(BookFormDto bfDto);


        bool Exists(Guid bookId);
    }
}
