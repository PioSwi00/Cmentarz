using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testowanie.Cmenatrz.MVC.Controllers;

namespace TestApi
{
    public class AllTestsGrobowceAPI
    {
       
        private readonly Mock<IGrobowiecService> _grobowiecServiceMock = new Mock<IGrobowiecService>();

        [Fact]
        public void GetGrobowceFilteredById_ReturnsNotFound_WhenGrobowiecIsNull()
        {
            
            _grobowiecServiceMock.Setup(service => service.GetGrobowceFilteredById(It.IsAny<int>())).Returns((Grobowiec)null);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

           
            var result = controller.GetGrobowceFilteredById(1);

           
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetGrobowceFilteredById_ReturnsOk_WhenGrobowiecExists()
        {
           
            var expectedGrobowiec = new Grobowiec();
            _grobowiecServiceMock.Setup(service => service.GetGrobowceFilteredById(It.IsAny<int>())).Returns(expectedGrobowiec);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

          
            var result = controller.GetGrobowceFilteredById(1);

           
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedGrobowiec, okResult.Value);
        }

        [Fact]
        public void GetAllGrobowce_ReturnsOk_WithSampleData()
        {
           
            var expectedGrobowce = new[] { new Grobowiec(), new Grobowiec() };
            _grobowiecServiceMock.Setup(service => service.PobierzWszystkieGrobowce()).Returns(expectedGrobowce);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            
            var result = controller.GetAllGrobowce();

          
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedGrobowce, okResult.Value);
        }

        [Fact]
        public void DodajZmarlegoDoGrobowca_ReturnsOk_WhenSuccessful()
        {
          
            var zmarly = new Zmarly();
            _grobowiecServiceMock.Setup(service => service.DodajZmarlegoDoGrobowca(It.IsAny<int>(), It.IsAny<Zmarly>()));
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

          
            var result = controller.DodajZmarlegoDoGrobowca(1, zmarly);

          
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DodajZmarlegoDoGrobowca_ReturnsBadRequest_WhenArgumentExceptionIsThrown()
        {
            
            var errorMessage = "Nic";
            _grobowiecServiceMock.Setup(service => service.DodajZmarlegoDoGrobowca(It.IsAny<int>(), It.IsAny<Zmarly>()))
                .Throws(new ArgumentException(errorMessage));
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

           
            var result = controller.DodajZmarlegoDoGrobowca(1, new Zmarly());

            
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(errorMessage, badRequestResult.Value);
        }
        [Fact]
        public void WyszukajGroby_ReturnsAllGrobowce_WhenNoFilters()
        {
            // Arrange
            var expectedGrobowce = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            _grobowiecServiceMock.Setup(service => service.WyszukajGroby(null, null, null, null, null)).Returns(expectedGrobowce);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.WyszukajGroby(null, null, null, null, null);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedGrobowce, okResult.Value);
        }

        [Fact]
        public void IloscOdwiedzajacych_ReturnsOk_WithCount()
        {
            // Arrange
            var expectedCount = 5;
            _grobowiecServiceMock.Setup(service => service.IloscOdwiedzajacych(It.IsAny<int>())).Returns(expectedCount);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.IloscOdwiedzajacych(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedCount, okResult.Value);
        }

        [Fact]
        public void PobierzWolneGroby_ReturnsOk_WithSampleData()
        {
            // Arrange
            var expectedWolneGroby = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            _grobowiecServiceMock.Setup(service => service.PobierzWolneGroby()).Returns(expectedWolneGroby);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.PobierzWolneGroby();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedWolneGroby, okResult.Value);
        }

        [Fact]
        public void PobierzZajeteGroby_ReturnsOk_WithSampleData()
        {
            // Arrange
            var expectedZajeteGroby = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            _grobowiecServiceMock.Setup(service => service.PobierzZajeteGroby()).Returns(expectedZajeteGroby);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.PobierzZajeteGroby();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedZajeteGroby, okResult.Value);
        }

        [Fact]
        public void PobierzGrobowceWlasciciela_ReturnsOk_WithSampleData()
        {
            // Arrange
            var expectedGrobyWlasciciela = new List<Grobowiec> { new Grobowiec(), new Grobowiec() };
            _grobowiecServiceMock.Setup(service => service.PobierzGrobyWlasciciela(It.IsAny<int>())).Returns(expectedGrobyWlasciciela);
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.PobierzGrobowceWlasciciela(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Same(expectedGrobyWlasciciela, okResult.Value);
        }
        [Fact]
        public void DodajOdwiedzajacegoDoGrobowca_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            _grobowiecServiceMock.Setup(service => service.DodajOdwiedzajacegoDoGrobowca(It.IsAny<int>(), It.IsAny<int>()));
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.DodajOdwiedzajacegoDoGrobowca(1, 2);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DodajOdwiedzajacegoDoGrobowca_ReturnsBadRequest_WhenArgumentExceptionIsThrown()
        {
            // Arrange
            var errorMessage = "Invalid data";
            _grobowiecServiceMock.Setup(service => service.DodajOdwiedzajacegoDoGrobowca(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new ArgumentException(errorMessage));
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.DodajOdwiedzajacegoDoGrobowca(1, 2);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public void UsunOdwiedzajacegoZGrobowca_ReturnsOk()
        {
            // Arrange
            _grobowiecServiceMock.Setup(service => service.UsunOdwiedzajacegoZGrobowca(It.IsAny<int>(), It.IsAny<int>()));
            var controller = new GrobowiecApiController(_grobowiecServiceMock.Object);

            // Act
            var result = controller.UsunOdwiedzajacegoZGrobowca(1, 2);

            // Assert
            Assert.IsType<OkResult>(result);
        }



    }
}
