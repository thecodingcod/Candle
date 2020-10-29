using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Candle.Logic.Services.Abstract;
using TCC.Candle.Web.ViewModels.Library;

namespace TCC.Candle.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly IShelfService _shelfService;
        private readonly IBookService _bookServic;
        public LibraryController(
            ILibraryService libraryService,
            IShelfService shelfService,
            IBookService bookService, IBookService bookServic)
        {
            _libraryService = libraryService;
            _shelfService = shelfService;
            _bookServic = bookServic;
        }

        public IActionResult Index(Guid id)
        {
            var library = _libraryService.GetLibraryById(id);
            var model = new IndexViewModel()
            {
                Id = id,
                Title = library.Title,
                Description = library.Description,
                ShelvesCount = _shelfService.GetShelvesCount(id),
                Shelves = _shelfService.GetAllShelves(id)?.Select(s => new ShelveListItem()
                {
                    Id = s.Id,
                    Title = s.Title,
                    BooksCount = _bookServic.GetBooksCount(s.Id),
                    Books = _bookServic.GetBooksOnShelf(s.Id)?.Select(b => new BookListItem()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        ImageUrl = b.ImgUrl,
                        LastModified = b.Modified
                    })
                })
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormViewModel model)
        {
            if (model == null) return View("CreateForm");
            if (!ModelState.IsValid) return View("CreateForm", model);
            var dto = model.ToLibraryFormDto();
            //HINT: Service shall return a validation dictionary to report to the UI
            bool result = _libraryService.AddLibrary(dto);
            if (!result) ModelState.AddModelError("::Service", "Something went wrong, Unable to add the library");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var lib = _libraryService.GetLibraryById(Id);
            return View("EditForm", new FormViewModel(lib));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormViewModel model)
        {
            if (model == null) return View("EditForm");
            if (!ModelState.IsValid) return View("EditForm", model);
            var dto = model.ToLibraryFormDto();
            //HINT: Service shall return a validation dictionary to report to the UI
            bool result = _libraryService.EditLibrary(dto);
            if (!result) ModelState.AddModelError("::Service", "Something went wrong, Unable to add the library");
            return RedirectToAction("Index", "Home");

        }


        //TODO : Post via XHR in javascript
        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            _libraryService.DeleteLibrary(Id);
            return RedirectToAction("Index", "Home");
        }
    }
}