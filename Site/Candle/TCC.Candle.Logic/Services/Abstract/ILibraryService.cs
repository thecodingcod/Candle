
using System;
using System.Collections.Generic;
using TCC.Candle.Data.Entities;
using TCC.Candle.Logic.DataTransferObjects;

namespace TCC.Candle.Logic.Services.Abstract
{
    public interface ILibraryService
    {
        /// <summary>
        /// Get Al lLibraries that belongs to a user
        /// </summary>
        /// <returns></returns>
        int GetLibrariesCount();

        /// <summary>
        /// Return the count of shelves in a library
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int GetLibraryShelvesCount(Guid Id);

        /// <summary>
        /// Return the count of books in a Library
        /// </summary>
        /// <param name="Id"> Library Id</param>
        /// <returns></returns>
        int GetLibraryBooksCount(Guid Id);

        /// <summary>
        /// Get All Libraries
        /// </summary>
        /// <returns></returns>
        IEnumerable<Library> GetAllLibraries();


        bool AddLibrary(LibraryFormDto libraryFormDto);

        LibraryFormDto GetById(Guid id);


        bool EditLibrary(Guid Id, LibraryFormDto libraryFormDto);

        bool DeleteLibrary(Guid Id);
    }
}
