using System;
using System.Collections.Generic;
using WebAppCarReg.Models;
using WebAppCarReg.Models.Data;
using Xunit;

namespace WebAppCarReg.Tests
{
    public class InMemoryCarRepoTests
    {
        [Fact]
        public void CarsReadListWorks()
        {
            //Arrange
            InMemoryCarRepo _carRepo = new InMemoryCarRepo();
            string brand = "testBrand";
            string modelName = "testCar";
            int year = 2000;


            //Act
            Car testCar = _carRepo.Create(brand,modelName,year);
            var resultList = _carRepo.Read();

            //Assert
            Assert.IsType<List<Car>>(resultList);
            Assert.True(resultList.Count > 0);
            Assert.Contains(testCar, resultList);
        }

        [Theory]
        [InlineData("Saab","900S",1990)]
        [InlineData("Volvo","745",1993)]
        [InlineData("Opel","Kadet",1983)]
        public void CarsCreate(string brand, string modelName, int year)
        {
            //Arrange
            InMemoryCarRepo _carRepo = new InMemoryCarRepo();

            //Act
            Car testCar = _carRepo.Create(brand, modelName, year);
            var resultList = _carRepo.Read();

            //Assert
            Assert.NotEqual(0, testCar.Id);
            //Assert.True(testCar.Id > 0);
            Assert.Equal(brand, testCar.Brand);
            Assert.Equal(modelName, testCar.ModelName);
            Assert.Equal(year, testCar.Year);

            Assert.Contains(testCar, resultList);
        }

        [Fact]
        public void CarsBadCreate()
        {
            //Arrange
            InMemoryCarRepo _carRepo = new InMemoryCarRepo();
            string brand = "badBrand", modelName = "badCar";
            int year = 1885;

            //Assert                        //Act
            Assert.Throws<Exception>(() => { _carRepo.Create(brand, modelName, year); });
        }
    }
}
