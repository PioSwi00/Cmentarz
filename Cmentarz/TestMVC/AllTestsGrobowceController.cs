using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Testowanie.Cmentarz.MVC.Controllers;
using Xunit;
namespace TestMVC
{
    public class GrobowceControllerTests
    {
        [Fact]
        public void WyszukajGroby_ReturnsViewWithAllGrobowce_WhenParametersAreNull()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            var allGrobowce = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            grobowiecServiceMock.Setup(service => service.PobierzWszystkieGrobowce())
                .Returns(allGrobowce);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.WyszukajGroby(null, null, null, null,null) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Grobowiec>>(result.Model);
            Assert.Equal(allGrobowce, result.Model);
        }

        [Fact]
        public void WyszukajGroby_ReturnsViewWithFilteredGrobowce_WhenParametersAreProvided()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            var filteredGrobowce = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            grobowiecServiceMock.Setup(service => service.WyszukajGroby(It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<decimal?>(), It.IsAny<String>()))
                .Returns(filteredGrobowce);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.WyszukajGroby(1, 2, "Lokalizacja", 100.0m,"A") as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Grobowiec>>(result.Model);
            Assert.Equal(filteredGrobowce, result.Model);
        }

        [Fact]
        public void IloscOdwiedzajacych_ReturnsView()
        {
            // Arrange
            var controller = new GrobowceController(Mock.Of<IGrobowiecService>());

            // Act
            var result = controller.IloscOdwiedzajacych() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IloscOdwiedzajacych_ReturnsViewWithIloscOdwiedzajacych_WhenIdIsValid()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            var iloscOdwiedzajacych = 5;
            grobowiecServiceMock.Setup(service => service.IloscOdwiedzajacych(It.IsAny<int>()))
                .Returns(iloscOdwiedzajacych);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.IloscOdwiedzajacych(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("WyswietlIloscOdwiedzajacych", result.ViewName);

            // Sprawdź ViewData dla IloscOdwiedzajacych
            Assert.True(result.ViewData.ContainsKey("IloscOdwiedzajacych"));
            Assert.Equal(iloscOdwiedzajacych, result.ViewData["IloscOdwiedzajacych"]);
        }

        [Fact]
        public void IloscOdwiedzajacych_ReturnsViewWithError_WhenServiceThrowsArgumentException()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            grobowiecServiceMock.Setup(service => service.IloscOdwiedzajacych(It.IsAny<int>()))
                .Throws(new ArgumentException("Invalid argument"));

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.IloscOdwiedzajacych(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Error", result.ViewName);
            Assert.Contains("Invalid argument", result.ViewData["ErrorMessage"].ToString());
        }

        [Fact]
        public void PobierzWolneGroby_ReturnsViewWithWolneGroby()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            var wolneGroby = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            grobowiecServiceMock.Setup(service => service.PobierzWolneGroby())
                .Returns(wolneGroby);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.PobierzWolneGroby() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Grobowiec>>(result.Model);
            Assert.Equal(wolneGroby, result.Model);
        }

        [Fact]
        public void DodajZmarlegoDoGrobowca_ReturnsViewWithZmarly_WhenGrobowiecExists()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            var existingGrobowiec = new Grobowiec { IdGrobowiec = 1, Lokalizacja= "Testowa" };
            grobowiecServiceMock.Setup(service => service.GetGrobowceFilteredById(It.IsAny<int>()))
                .Returns(existingGrobowiec);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.DodajZmarlegoDoGrobowca(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Zmarly>(result.Model);
        }

        [Fact]
        public void DodajZmarlegoDoGrobowca_ReturnsViewWithError_WhenGrobowiecNotFound()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            grobowiecServiceMock.Setup(service => service.GetGrobowceFilteredById(It.IsAny<int>()))
                .Returns((Grobowiec)null);

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.DodajZmarlegoDoGrobowca(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Error", result.ViewName);
            Assert.Contains("Nie znaleziono grobowca o podanym ID.", result.ViewData["ErrorMessage"].ToString());
        }
        [Fact]
        public void WyszukajGroby_ReturnsEmptyView_WhenNoGrobWasFound()
        {
            // Arrange
            var grobowiecServiceMock = new Mock<IGrobowiecService>();
            grobowiecServiceMock.Setup(service => service.PobierzWszystkieGrobowce())
                .Returns(new List<Grobowiec>());

            var controller = new GrobowceController(grobowiecServiceMock.Object);

            // Act
            var result = controller.WyszukajGroby(null, null, null, null,null) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Model as IEnumerable<Grobowiec>);
        }

        [Fact]
        public void IloscOdwiedzajacych_ReturnsViewWithError_WhenIdIsInvalid()
        {
            // Arrange
            var controller = new GrobowceController(Mock.Of<IGrobowiecService>());

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => controller.IloscOdwiedzajacych(0));
            Assert.Equal("Invalid argument", ex.Message);
        }

      
       

       


    }
}