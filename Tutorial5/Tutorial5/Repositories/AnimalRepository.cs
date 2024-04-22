using Microsoft.Data.SqlClient;
using Tutorial5.Models;

namespace Tutorial5.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<Animal> GetAnimals()
    {
        // // Otwieramy połączenie
        // using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        // connection.Open();
        //
        // // Defincja command
        // SqlCommand command = new SqlCommand();
        // command.Connection = connection;
        // command.CommandText = "SELECT * FROM Animal";
        //     
        // // Wykonanie zapytania
        // var reader = command.ExecuteReader();
        //     
        // List<Animal> animals = new List<Animal>();
        //     
        // int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        // int nameOrdinal = reader.GetOrdinal("Name");
        // int descriptionOrdinal = reader.GetOrdinal("Description");
        // int categoryOrdinal = reader.GetOrdinal("Category");
        // int areaOrdinal = reader.GetOrdinal("Area");
        //     
        // while (reader.Read())
        // {
        //     animals.Add(new Animal()
        //     {
        //         IdAnimal = reader.GetInt32(idAnimalOrdinal),
        //         Name = reader.GetString(nameOrdinal),
        //         Description=reader.GetString(descriptionOrdinal),
        //         Category = reader.GetString(categoryOrdinal),
        //         Area = reader.GetString(areaOrdinal)
        //     });
        // }

        throw new NotImplementedException();
    }

    public int AddAnimal(Animal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
            
        // Defincja command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName,@animalDescription,@animalCategory,@animalArea)"; ;
        command.Parameters.AddWithValue("@animalName", animal.Name);
        command.Parameters.AddWithValue("@animalDescription", animal.Description);
        command.Parameters.AddWithValue("@animalCategory", animal.Category);
        command.Parameters.AddWithValue("@animalArea", animal.Area);
            
        // Wykonanie zapytania
        return command.ExecuteNonQuery();
    }

    public Animal GetAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal WHERE IdAnimal=@IdAnimal";
        command.Parameters.AddWithValue("@IdAnimal", id);
        var reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }
            var animal= new Animal()
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString(),
                Area = reader["Area"].ToString() 
            };
            return animal;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal SET Name=@animalName,  Description=@animalDescription,Category=@animalCategory, Area=@animalArea WHERE IdAnimal = @IdAnimal";
        command.Parameters.AddWithValue("@IdAnimal", id);
        command.Parameters.AddWithValue("@animalName", animal.Name);
        command.Parameters.AddWithValue("@animalDescription", animal.Description);
        command.Parameters.AddWithValue("@animalCategory", animal.Category);
        command.Parameters.AddWithValue("@animalArea", animal.Area);

        return command.ExecuteNonQuery();
    }

    public int DeleteAnimal(int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";

        command.Parameters.AddWithValue("@IdAnimal", id);

        return command.ExecuteNonQuery();
    }
}