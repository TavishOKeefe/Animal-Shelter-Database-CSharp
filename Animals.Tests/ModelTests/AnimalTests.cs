using Microsoft.VisualStudio.TestTools.UnitTesting;
using Animals.Models;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace Animals.Tests
{
    [TestClass]
    public class AnimalTests : IDisposable
    {
      public void Dispose()
      {
        Animal.ClearAll();
      }

      public AnimalTests()
      {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=AnimalsDB_Test;";
      }

        [TestMethod]
        public void AnimalConstructor_Instantiates_Object()
        {
          //Arrange
          Animal newAnimal = new Animal("testName", "testType", 'M', DateTime.Now, "testBreed");

          //Act

          //Assert
          Assert.AreEqual(typeof(Animal), newAnimal.GetType());
        }

        [TestMethod]
        public void AnimalObject_SavesIntoDB_AnimalList()
        {
          //Arrange
          Animal newAnimal = new Animal("testName", "testType", 'M', DateTime.Now, "testBreed");

          //Act
          newAnimal.Save();
          List<Animal> result = Animal.GetAll();
          List<Animal> testList = new List<Animal>{newAnimal};

          //Assert
          CollectionAssert.AreEqual(testList, result);

        }


    }
}
