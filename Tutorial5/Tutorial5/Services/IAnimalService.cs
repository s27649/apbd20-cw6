using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    int AddAnimal(Animal animal);
    Animal GetAnimal(int id);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}