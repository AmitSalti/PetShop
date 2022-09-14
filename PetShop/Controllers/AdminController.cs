using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repository;

namespace PetShop.Controllers
{
    public class AdminController : Controller
    {
        readonly IModifyAnimal repoModify;
        readonly IPresentData repoPresent;
        public AdminController(IModifyAnimal modifyService, IPresentData presrntService)
        {
            repoModify = modifyService;
            repoPresent = presrntService;
        }
        public IActionResult Index(string category)
        {
            if (category == null || category == "Show All")
                return View(repoPresent.GetAllAnimals());
            return View(repoPresent.GetAnimalsByCategory(category));
        }
        public IActionResult Delete(int id)
        {
            repoModify.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Insert(Animal animal, int categoryId)
        {
            animal.AnimalId = repoPresent.GetLastAnimaId();
            if (ModelState.IsValid)
            {
                animal.CategoryId = categoryId;
                repoModify.Insert(animal);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) => View(repoPresent.GetAnimalsById(id));
        public IActionResult EditSubmited(Animal animal, int categoryId)
        {
            if (ModelState.IsValid)
            {
                animal.CategoryId = categoryId;
                repoModify.Update(animal);
                return RedirectToAction("Index");
            }
            return RedirectToAction("index");
        }
        public IActionResult AddNewAnimal() => View();
    }
}
