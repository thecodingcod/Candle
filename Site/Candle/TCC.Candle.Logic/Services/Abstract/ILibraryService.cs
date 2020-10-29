
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
        /// Get All Libraries
        /// </summary>
        /// <returns></returns>
        IEnumerable<Library> GetAllLibraries();

        LibraryFormDto GetLibraryById(Guid id);
        string GetLibraryDescription(Guid id);


        bool AddLibrary(LibraryFormDto libraryFormDto);



        bool EditLibrary(LibraryFormDto libraryFormDto);

        bool DeleteLibrary(Guid id);



    }
}

