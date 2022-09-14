using PetShop.Models;

namespace PetShop.Repository
{
    public interface IModifyAnimal
    {
        void Insert(Animal animal);
        void Update(Animal animals);
        void Delete(int id);
        void Addcomment(Animal animal, string comment);
    }
}
