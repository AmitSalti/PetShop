
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Repository
{
    public class AnimalRepo : IModifyAnimal, IPresentData
    {
        private AnimalContext _context;
        public AnimalRepo(AnimalContext context)
        {
            _context = context;
        }
        public void Insert(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }
        public void Update(Animal animal)
        {
            _context.Update(animal);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var animal = _context.Animals!.SingleOrDefault(a => a.AnimalId == id);
            _context.Animals!.Remove(animal!);
            _context.SaveChanges();
        }
        public void Addcomment(Animal animal, string content)
        {
            var comment = new Comment { Content = content, AnimalId = animal.AnimalId, Animal = animal };
            animal!.Comments!.Add(comment);
            _context.SaveChanges();
        }
        public IEnumerable<Animal> GetAllAnimals() => _context.Animals!.Include(a => a.Category!).ThenInclude(a => a.Animals!).ThenInclude(a => a.Comments!).ToList();
        public IEnumerable<Category> GetCategories() => _context.Categories!;
        public IEnumerable<Comment> GetComments() => _context.Comments!;
        public IEnumerable<Animal> GetPopularAnimals() => _context.Animals!.Include(a => a.Comments).OrderByDescending(c => c.Comments!.Count()).Take(2).ToList();
        public IEnumerable<Animal> GetAnimalsByCategory(string category) => _context.Animals!.Include(a => a.Category!).ThenInclude(a => a.Animals!).ThenInclude(a => a.Comments!).Where(a => a.Category!.Name == category).ToList();
        public Animal GetAnimalsById(int id) => _context.Animals!.Include(a => a.Category!).ThenInclude(a => a.Animals!).ThenInclude(a => a.Comments!).Single(a => a.AnimalId == id);
        public int GetLastAnimaId() => (int)_context.Animals!.ToArray().Last().AnimalId + 1;
    }
}
