using Tutorial5.Models;
using Tutorial5.Repositories;

namespace Tutorial5.Services;

public class AnimalService: IAnimalService
{
    private readonly IAnimalRepository _iAnimalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _iAnimalRepository = animalRepository;
    }
    public IEnumerable<Animal> GetAnimals()
    {
        return _iAnimalRepository.GetAnimals();
    }

    public int AddAnimal(Animal animal)
    {
        return _iAnimalRepository.AddAnimal(animal);
    }

    public Animal GetAnimal(int id)
    {
        return _iAnimalRepository.GetAnimal(id);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return _iAnimalRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return _iAnimalRepository.DeleteAnimal(id);
    }
}