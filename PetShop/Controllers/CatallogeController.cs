using Microsoft.AspNetCore.Mvc;
using PetShop.Repository;

namespace PetShop.Controllers
{
    public class CatallogeController : Controller
    {
        IPresentData repoPresent;
        IModifyAnimal repoModify;
        public CatallogeController(IPresentData repoPresent, IModifyAnimal repoModify)
        {
            this.repoPresent = repoPresent;
            this.repoModify = repoModify;
        }
        public IActionResult Index(string category)
        {
            if (category == null || category == "Show All")
                return View(repoPresent.GetAllAnimals());
            return View(repoPresent.GetAnimalsByCategory(category));
        }
        public IActionResult AnimalDetailes(int id) => View(repoPresent.GetAnimalsById(id));
        public IActionResult AddComment(string comment, int id)
        {
            var animal = repoPresent.GetAnimalsById(id);
            repoModify.Addcomment(animal, comment);
            return View("AnimalDetailes", animal);
        }
    }
}
