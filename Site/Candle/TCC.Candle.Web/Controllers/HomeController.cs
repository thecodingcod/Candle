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
        private ILibraryService libService;
        private IShelfService shelfService;
        private IBookService bookService;
        public HomeController(
            ILibraryService libService,
            IShelfService shelfService,
            IBookService bookService)
        {
            this.libService = libService;
            this.shelfService = shelfService;
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                LibrariesCount = libService.GetLibrariesCount(),
                Libraries = libService.GetAllLibraries().Select(li => new IndexListItem
                {
                    Id = li.Id,
                    Name = li.Title,
                    LastModified = li.Modified,
                    BooksCount = bookService.GetLibraryBooksCount(li.Id),
                    ShelvesCount = shelfService.GetShelvesCount(li.Id)
                })
            };
            return View(viewModel);
        }


    }

}
