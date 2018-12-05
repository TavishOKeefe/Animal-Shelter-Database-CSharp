using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Animals.Models
{
  public class Animal
  {
    public string AnimalName { get; set; }
    public string AnimalType { get; set; }
    public char AnimalSex { get; set; }
    public DateTime AnimalDateOfAdmittance { get; set; }
    public string AnimalBreed { get; set; }
    public int AnimalId { get; set; }

    // These lists are created in the DB
    // private static List<string> RabbitBreed = new List<string>{"American Fuzzy Lop","Britannia Petite","Dutch","Dwarf Hotot","Havana","Himalayan","Holland Lop"}
    //
    // private static List<string> DogBreed = new List<string>{"Labrador",	"German Shepherd", "Golden Retriever", "French Bulldog", "Bulldog", "Beagle", "Poodle", "Rottweiler", "Yorkshire Terrier", "German Shorthaired Pointer"}
    //
    // private static List<string> CatBreed = new List<string>{"Exotic Shorthair","Persian","Maine Coon","Ragdoll","British Shorthair","American Shorthair","Abyssinian","Sphynx","Siamese","Scottish Fold"}

    public Animal (string animalName, string animalType, char animalSex, DateTime animalDateOfAdmittance, string animalBreed, int id = 0)
    {
      this.AnimalName = animalName;
      this.AnimalType = animalType;
      this.AnimalSex = animalSex;
      this.AnimalDateOfAdmittance = animalDateOfAdmittance;
      this.AnimalBreed = animalBreed;
      this.AnimalId = id;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is Animal))
      {
        return false;
      }
      else
      {
        Animal newAnimal = (Animal) otherAnimal;
        bool idEquality = (this.AnimalId == newAnimal.AnimalId);
        bool nameEquality = (this.AnimalName == newAnimal.AnimalName);
        bool typeEquality = (this.AnimalType == newAnimal.AnimalType);
        bool sexEquality = (this.AnimalSex == newAnimal.AnimalSex);
        // bool dateOfAdmittanceEquality = (this.AnimalDateOfAdmittance == newAnimal.AnimalDateOfAdmittance);
        bool breedEquality = (this.AnimalBreed == newAnimal.AnimalBreed);
        return (idEquality && nameEquality && typeEquality && sexEquality && breedEquality);
      }
    }

    public static List<Animal> GetAll()
    {
      List<Animal> allAnimals = new List<Animal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM AnimalList;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string type = rdr.GetString(2);
        char sex = rdr.GetChar(3);
        DateTime dateofadmittance = rdr.GetDateTime(4);
        string breed = rdr.GetString(5);
        Animal newAnimal = new Animal(name, type, sex, dateofadmittance, breed, itemId);
        allAnimals.Add(newAnimal);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAnimals;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM AnimalList;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO AnimalList (name, type, sex, dateofadmittance, breed) VALUES (@Name, @Type, @Sex, @Dateofadmittance, @breed);";
      cmd.Parameters.AddWithValue("@Name",this.AnimalName);
      cmd.Parameters.AddWithValue("@Type",this.AnimalType);
      cmd.Parameters.AddWithValue("@Sex",this.AnimalSex);
      cmd.Parameters.AddWithValue("@Dateofadmittance",this.AnimalDateOfAdmittance);
      cmd.Parameters.AddWithValue("@breed",this.AnimalBreed);
      cmd.ExecuteNonQuery();
      this.AnimalId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
