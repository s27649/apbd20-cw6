using Tutorial5.Models;

namespace Tutorial5.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    int AddAnimal(Animal animal);
    Animal GetAnimal(int id);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}