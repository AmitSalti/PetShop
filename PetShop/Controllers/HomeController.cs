using Microsoft.AspNetCore.Mvc;
using PetShop.Repository;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly IPresentData repo;
        public HomeController(IPresentData repo) => this.repo = repo;
        public IActionResult Index() => View(repo.GetPopularAnimals());
    }
}