using System;
namespace Animals.Models
{
    public class Animal
    {
        public Animal()
        {
            public string AnimalName { get; set; }
            public string AnimalType { get; set; }
            public char AnimalSex { get; set; }
            public DateTime AnimalDateOfAdmittance { get; set; }
            public string AnimalBreed { get; set; }
            private static List<string> BunnyBreed = new List<string>{"American Fuzzy Lop","Britannia Petite","Dutch","Dwarf Hotot","Florida White","Havana","Himalayan","Holland Lop"}
            private static List<string> DogBreed = new List<string>{"Labrador",	"German Shepherd", "Golden Retrievers", "French Bulldogs", "Bulldogs", "Beagles", "Poodles", "Rottweilers", "Yorkshire Terriers", "German Shorthaired Pointer"}
            private static List<string> CatBreed = new List<string>{"Exotic Shorthair","Persian","Maine Coon","Ragdoll","British Shorthair","American Shorthair","Abyssinian","Sphynx","Siamese","Scottish Fold"}
        }
    }
}
