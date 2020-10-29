using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Logic.Services.Abstract;
using TCC.Candle.Web.ViewModels.Shelf;

namespace TCC.Candle.Web.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfService;
        private readonly IBookService _bookService;

        public ShelfController(IShelfService shelfService, IBookService bookService)
        {
            _shelfService = shelfService;
            _bookService = bookService;
        }

        public IActionResult Index(Guid Id)
        {
            var shelf = _shelfService.GetShelfById(Id);
            // TODO : Change to 404 page
            if (shelf == null) return RedirectToAction("Index", "Home");
            var model = new IndexViewModel()
            {
                Id = shelf.Id,
                Title = shelf.Title,
                Description = shelf.Description,
                BooksCount = _bookService.GetBooksCount(shelf.Id),
                Books = _bookService.GetBooksOnShelf(Id)?.Select(b => new BookItem()
                {
                    Id = b.Id,
                    Title = b.Title,
                    ImageUrl = b.ImgUrl,
                })
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(Guid libraryId)
        {

            // TODO Ensure that library Exists first !
            var model = new FormViewModel()
            {
                LibraryId = libraryId
            };

            return View("CreateForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormViewModel model)
        {
            if (!ModelState.IsValid) return View("CreateForm", model);
            var dto = model.ToShelfFormDto();
            bool result = _shelfService.AddShelf(dto);
            if (!result) return View("CreateForm", model);
            return RedirectToAction("Index", "Library", new { Id = model.LibraryId });
        }

        [HttpGet]
        public IActionResult Edit([FromQuery]Guid shelfId, [FromQuery]Guid libraryId)
        {
            var model = new FormViewModel(_shelfService.GetShelfById(shelfId));
            if (!model.Parsed) return RedirectToAction("Index", "Library", new { Id = libraryId });
            return View("EditForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormViewModel model)
        {
            if (!ModelState.IsValid) return View("EditForm", model);
            var dto = model.ToShelfFormDto();
            bool result = _shelfService.EditShelf(dto);
            if (!result) return View("EditForm", model);
            return RedirectToAction("Index", "Library", new { Id = model.LibraryId });
        }
    }
}