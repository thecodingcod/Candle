using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Logic.Services.Abstract;
using TCC.Candle.Logic.Services.Concrete;
using TCC.Candle.Web.ViewModels.Book;

namespace TCC.Candle.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IShelfService _shelfService;
        private readonly IBookService _bookService;
        private ILibraryService _libraryService;


        public BookController(ILibraryService libraryService, IShelfService shelfService, IBookService bookService)
        {
            _bookService = bookService;
            _libraryService = libraryService;
            _shelfService = shelfService;
        }
        public IActionResult Index(Guid Id)
        {
            if (!_bookService.Exists(Id)) return RedirectToAction("Index", "Home");
            var book = _bookService.GetBookById(Id);
            var model = new IndexViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Subtitle = book.SubTitle,
                Description = book.Description,
                ISBN13 = book.ISBN13,
                Pages = book.Pages,
                Author = book.Author,
                ShelfId = book.ShelfId,
                Shelf = _shelfService.GetShelfById(book.ShelfId)?.Title,
                LibraryId = _shelfService.GetShelfById(book.ShelfId).LibraryId,
                Library = _libraryService.GetLibraryById(_shelfService.GetShelfById(book.ShelfId).LibraryId)?.Title
            };
            return View("Index", model);
        }


        [HttpGet]
        public IActionResult Create(Guid shelfId)
        {
            // TODO Instead redirect to 404 pages
            if (!_shelfService.Exists(shelfId)) return RedirectToAction("Index", "Home");
            var model = new FormViewModel
            {
                ShelfId = shelfId
            };

            return View("CreateForm", model);
        }


        public IActionResult Create(FormViewModel form)
        {
            if (!ModelState.IsValid) return View("CreateForm", form);
            var book = form.ToBookFormDto();
            bool result = _bookService.AddBook(book);
            if (!result)
            {
                ModelState.AddModelError("Unknown", "Something went wrong !");
                return View("CreateForm", form);
            }
            return RedirectToAction("Index", "Shelf", new { Id = book.ShelfId });
        }


        [HttpGet]
        public IActionResult Edit(Guid bookId, Guid shelfId)
        {
            // TODO Instead redirect to 404 page
            if (!_shelfService.Exists(shelfId)) return RedirectToAction("Index", "Home");
            if (!_bookService.Exists(bookId)) return RedirectToAction("Index", "Library", new { Id = _shelfService.GetShelfById(shelfId).LibraryId });
            var book = _bookService.GetBookById(bookId);
            var model = new FormViewModel(book);
            return View("EditForm", model);
        }


        public IActionResult Edit(FormViewModel form)
        {
            if (!ModelState.IsValid) return View("CreateForm", form);
            var book = form.ToBookFormDto();
            bool result = _bookService.EditBook(book);
            if (!result)
            {
                ModelState.AddModelError("Unknown", "Something went wrong !");
                return View("EditForm", form);
            }
            return RedirectToAction("Index", "Book", new { Id = book.Id });
        }
    }
}