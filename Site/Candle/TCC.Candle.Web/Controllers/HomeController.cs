using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using TCC.Candle.Logic.Services.Abstract;
using TCC.Candle.Web.ViewModels.Home;

namespace TCC.Candle.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILibraryService service;
        public HomeController(ILibraryService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                LibrariesCount = service.GetLibrariesCount(),
                Libraries = service.GetAllLibraries().Select(li => new IndexListItem
                {
                    Id = li.Id,
                    Name = li.Title,
                    LastModified = li.Modified,
                    BooksCount = service.GetLibraryBooksCount(li.Id),
                    ShelvesCount = service.GetLibraryShelvesCount(li.Id)
                })
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LibraryFormViewModel model)
        {
            if (model == null) return View("CreateForm");
            if (!ModelState.IsValid) return View("CreateForm", model);
            var dto = model.ToLibraryFormDto();
            //HINT: Service shall return a validation dictionary to report to the UI
            bool result = service.AddLibrary(dto);
            if (!result) ModelState.AddModelError("::Service", "Something went wrong, Unable to add the library");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var lib = service.GetById(Id);
            return View("EditForm", new LibraryFormViewModel(lib));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid Id, LibraryFormViewModel model)
        {
            if (model == null) return View("EditForm");
            if (!ModelState.IsValid) return View("EditForm", model);
            var dto = model.ToLibraryFormDto();
            //HINT: Service shall return a validation dictionary to report to the UI
            bool result = service.EditLibrary(Id, dto);
            if (!result) ModelState.AddModelError("::Service", "Something went wrong, Unable to add the library");
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            service.DeleteLibrary(Id);
            return RedirectToAction(nameof(Index));
        }
    }

}
