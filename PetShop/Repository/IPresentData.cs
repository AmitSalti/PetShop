using PetShop.Models;

namespace PetShop.Repository
{
    public interface IPresentData
    {
        IEnumerable<Animal> GetAllAnimals();
        IEnumerable<Category> GetCategories();
        IEnumerable<Comment> GetComments();
        IEnumerable<Animal> GetPopularAnimals();
        IEnumerable<Animal> GetAnimalsByCategory(string category);
        Animal GetAnimalsById(int id);
        int GetLastAnimaId();
    }
}
