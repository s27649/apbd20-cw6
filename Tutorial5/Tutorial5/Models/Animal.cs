namespace Tutorial5.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
    public void Animals(Animal animal)
    {
        IdAnimal = animal.IdAnimal;
        Name = animal.Name; 
        Description = animal.Description; 
        Category = animal.Category;
        Area = animal.Area;
    }
}