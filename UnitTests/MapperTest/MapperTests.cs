using System;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.EntityModels;
using Models.ViewModels;
using nieruchomości;
using UnitTests.Helpers;

namespace UnitTests.MapperTest
{
    [TestClass]
    public class MapperTests
    {
        public MapperTests()
        {
            MapperConfig.Register();
        }
        [TestMethod]
        public void T001_FlatToAdminToShowWithNullWorker()
        {
            // Arrange
            var flat = EntitiesCreator.GetFlat();

            // Act
            var result = Mapper.Map<AdminAdvertToShow>(flat);

            // Assert
            Assert.AreEqual(flat.Id, result.Id);
            Assert.AreEqual(flat.CreatedAt, result.CreatedAt);
            Assert.AreEqual(flat.Deleted, result.Deleted);
            Assert.AreEqual(flat.Title, result.Title);
            Assert.AreEqual(flat.City, result.City);
            Assert.AreEqual(flat.Visible, result.Visible);
            Assert.AreEqual(result.AdType, AdType.Flat);
        }

        [TestMethod]
        public void T002_HouseToAdminToShowWithNullWorker()
        {
            // Arrange
            var house = EntitiesCreator.GetHouse();

            // Act
            var result = Mapper.Map<AdminAdvertToShow>(house);

            //Assert
            Assert.AreEqual(result.AdType, AdType.House);
            Assert.AreEqual(result.City, house.City);
            Assert.AreEqual(result.CreatedAt, house.CreatedAt);
            Assert.AreEqual(result.Deleted, house.Deleted);
            Assert.AreEqual(result.Id, house.Id);
            Assert.AreEqual(result.Visible, house.Visible);
            Assert.AreEqual(result.Title,house.Title);
        }

        [TestMethod]
        public void T003_LandToAdminToShowWithNullWorker()
        {
            // Arrange
            var land = EntitiesCreator.GetLand();
            
            // Act
            var result = Mapper.Map<AdminAdvertToShow>(land);

            // Assert
            Assert.AreEqual(result.AdType, AdType.Land);
            Assert.AreEqual(result.City , land.City);
            Assert.AreEqual(result.Deleted, land.Deleted);
            Assert.AreEqual(result.CreatedAt, land.CreatedAt);
            Assert.AreEqual(result.Id, land.Id);
            Assert.AreEqual(result.Title, land.Title);
            Assert.AreEqual(result.Visible, land.Visible);
        }

        [TestMethod]
        public void T004_AdvertNumberIsProper()
        {
            // Arrange
            var flat = EntitiesCreator.GetFlat();
            var house = EntitiesCreator.GetHouse();
            var land = EntitiesCreator.GetLand();

            flat.Id = 10;
            house.Id = 10;
            land.Id = 10;

            // Act
            var resultFlat = Mapper.Map<AdminAdvertToShow>(flat);
            var resultHouse = Mapper.Map<AdminAdvertToShow>(house);
            var resultLand = Mapper.Map<AdminAdvertToShow>(land);

            // Assert
            Assert.AreEqual(resultFlat.Number, (10*9999).ToString()+12);
            Assert.AreEqual(resultHouse.Number, (10*9999).ToString()+14);
            Assert.AreEqual(resultLand.Number, (10*9999).ToString()+18);
        }
    }
}
