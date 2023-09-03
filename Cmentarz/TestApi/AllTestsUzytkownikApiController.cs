using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Testowanie.Cmenatrz.MVC.Controllers;
using Testowanie.Cmenatrz.MVC.Models;

namespace TestApi
{
    public class AllTestsUzytkownikApiController
    {
        private UzytkownikApiController CreateControllerWithMocks(out Mock<IUzytkownikService> uzytkownikServiceMock)
        {
            uzytkownikServiceMock = new Mock<IUzytkownikService>();
            var controller = new UzytkownikApiController(uzytkownikServiceMock.Object);
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "1") // jakis tam testowy z id 1
        }));
            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
            return controller;
        }

        [Fact]
        public void KupowanieGrobowca_Get_ReturnsOk()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out _);

            // Act
            var result = controller.KupowanieGrobowca(1, 2) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
           
        }
        [Fact]
        public void KupowanieGrobowca_Get_ZajetyGrobowiec_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            uzytkownikServiceMock.Setup(service => service.KupGrobowiec(1, 2))
                                .Throws(new Exception("Grobowiec jest już zajęty."));

            // Act
            var result = controller.KupowanieGrobowca(1, 2) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
           
        }

        [Fact]
        public void KupowanieGrobowca_Post_ReturnsOk()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            var viewModel = new KupowanieGrobowcaViewModel
            {
                IdUzytkownik = 1,
                IdGrobowiec = 2
            };
            uzytkownikServiceMock.Setup(service => 
            service.KupGrobowiec(viewModel.IdUzytkownik, viewModel.IdGrobowiec))
                .Returns(new Grobowiec()); 

            // Act
            var result = controller.KupowanieGrobowca(viewModel) as IActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void Login_Post_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out _);
            controller.ModelState.AddModelError("Login", "Nieprawidłowy login");

            // Act
            var result = controller.Login(new LoginViewModel()) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
   
        }
        [Fact]
        public void Login_Post_ValidModel_ReturnsOk()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            var viewModel = new LoginViewModel
            {
                Login = "PoprawnyLogin",
                Haslo = "PoprawneHaslo"
            };
            uzytkownikServiceMock.Setup(service => service.Login(viewModel.Login, viewModel.Haslo))
                                .Returns(new Uzytkownik { IdUzytkownik = 1 });

            // Act
            var result = controller.Login(viewModel) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
    
        }
        [Fact]
        public void UsunUzytkownika_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            uzytkownikServiceMock.Setup(service => service.UsunUzytkownika(1))
                                .Throws(new Exception("Użytkownik o podanym identyfikatorze nie istnieje."));

            // Act
            var result = controller.UsunUzytkownika() as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
         
        }
        [Fact]
        public void ZmienHaslo_InvalidData_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            uzytkownikServiceMock.Setup(service => service.ZmienHaslo(1, "NoweHaslo"))
                                .Throws(new Exception("Użytkownik o podanym identyfikatorze nie istnieje."));

            // Act
            var result = controller.ZmienHaslo("NoweHaslo") as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
    
        }
        [Fact]
        public void KupowanieGrobowca_Get_InvalidIds_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);

            // Act
            var result = controller.KupowanieGrobowca(0, 0) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);

        }
        [Fact]
        public void DodajUzytkownika_DuplicateLogin_ReturnsBadRequest()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out var uzytkownikServiceMock);
            uzytkownikServiceMock.Setup(service => service.DodajUzytkownika(It.IsAny<Uzytkownik>()))
                                .Throws(new Exception("Isnieje juz taki ziomo"));

            // Act
            var result = controller.DodajUzytkownika(new Uzytkownik()) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
       
        [Fact]
        public void ValidateJwtToken_InvalidToken_ReturnsFalse()
        {
            // Arrange
            var controller = CreateControllerWithMocks(out _);
            var invalidToken = "nieprawidlowy-token-jwt";

            // Act
            var isValid = controller.ValidateJwtToken(invalidToken);

            // Assert
            Assert.False(isValid);
        }








    }
}
