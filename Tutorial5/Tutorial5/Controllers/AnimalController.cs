using Microsoft.AspNetCore.Mvc;
using Tutorial5.Models;
using Tutorial5.Services;

namespace Tutorial5.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = _animalService.GetAnimals();
            return Ok(animals.OrderBy(animal=>animal.Name));
        }
        
        [HttpGet("{OrderBy}")]
        public IActionResult GetSortedAnimals(string OrderBy)
        {
            var animal = _animalService.GetAnimals();
            
            switch (OrderBy)
            {
                case "Name" :
                    return Ok(animal.OrderBy(a => a.Name));
                case "Description":
                    return Ok(animal.OrderBy(a => a.Description));
                case "Category":
                    return Ok(animal.OrderBy(a => a.Category));
                case "Area":
                    return Ok(animal.OrderBy(a => a.Area));
                default:    
                    return StatusCode(StatusCodes.Status403Forbidden); 
            }
        }


        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            var animals = _animalService.AddAnimal(animal);
            return Created();
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animals = _animalService.GetAnimal(id);
            if (animals == null)
            {
                return NotFound($"Animal with id {id} doesn't exist");
            }
            return Ok(animals);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal animal)
        {
            var animals = _animalService.UpdateAnimal(id,animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animals = _animalService.DeleteAnimal(id);
            return NoContent();
        }
}