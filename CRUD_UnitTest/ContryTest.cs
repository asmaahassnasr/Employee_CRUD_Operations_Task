using CRUD_APIs.Models;
using CRUD_APIs.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace CRUD_UnitTest
{
    [TestClass]
    public class ContryTest
    {
        CountryRepository repository;
        AppDbContext dbContext;

        [SetUp]
        public void SetUp()
        {
            repository = new CountryRepository(dbContext);
        }
        [TestMethod]
        public async void AddCountry_Should_Save()
        {
            //Arrange
            Country country = new Country() { CountryName = "TestCountry", CountryCode = "TT" };

            //Act
            await repository.AddCountry(country);
            Country expected = await repository.GetCountryById(country.CountryId);
            //Assert
            NUnit.Framework.Assert.That(expected, Is.EqualTo(country));
        }
    }
}
