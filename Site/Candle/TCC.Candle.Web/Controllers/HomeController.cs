using Microsoft.AspNetCore.Mvc;
using TCC.Candle.Data.Entities;
using TCC.Candle.Data.Repositories;

namespace TCC.Candle.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Book> repo;
        public HomeController(IRepository<Book> repo)
        {
            this.repo = repo;
        }
        public string Index()
        {

            return repo.GetById(new System.Guid("1397ce68-1aa1-41cd-b3ee-04504b71aef8")).Title;
        }
    }
}
