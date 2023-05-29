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
using Testowanie.Cmenatrz.MVC.Models;

namespace TestMVC
{
    public class UnitTestUzytkownikController
    {
        [Fact]
        public void Index_ReturnsViewResultWithGrobowiec()
        {
            // Arrange
            var mockUzytkownikService = new Mock<IUzytkownikService>();
            var grobowiec = new Grobowiec();
            mockUzytkownikService.Setup(service => service.KupGrobowiec(It.IsAny<int>(), It.IsAny<int>()))
                                 .Returns(grobowiec);

            var controller = new UzytkownikController(mockUzytkownikService.Object);
            var viewModel = new KupowanieGrobowcaViewModel
            {
                IdUzytkownik = 1,
                IdGrobowiec = 2
            };

            // Act
            var result = controller.Index(viewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Grobowiec>(viewResult.Model);
            Assert.Equal(grobowiec, model);
        }

        [Fact]
        public void Login_WithValidCredentials_RedirectsToWitajAction()
        {
            // Arrange
            var mockUzytkownikService = new Mock<IUzytkownikService>();
            var controller = new UzytkownikController(mockUzytkownikService.Object);
            var viewModel = new LoginViewModel
            {
                Login = "test",
                Haslo = "password"
            };

            mockUzytkownikService.Setup(service => service.Login(viewModel.Login, viewModel.Haslo))
                        .Returns(new Uzytkownik { Login = viewModel.Login });

            // Act
            var result = controller.Login(viewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Witaj", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Login_WithInvalidCredentials_ReturnsViewResultWithModelError()
        {
            // Arrange
            var mockUzytkownikService = new Mock<IUzytkownikService>();
            var controller = new UzytkownikController(mockUzytkownikService.Object);
            var viewModel = new LoginViewModel
            {
                Login = "test",
                Haslo = "incorrect"
            };

            // Act
            var result = controller.Login(viewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelState = Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>(viewResult.ViewData.ModelState);
            Assert.True(modelState.ContainsKey(string.Empty));
            Assert.Equal("Nieprawidłowy login lub hasło.", modelState[string.Empty].Errors[0].ErrorMessage);
        }

        [Fact]
        public void KupowanieGrobowca_ReturnsViewResultWithKupowanieGrobowcaViewModel()
        {
            // Arrange
            var mockUzytkownikService = new Mock<IUzytkownikService>();
            var controller = new UzytkownikController(mockUzytkownikService.Object);

            // Act
            var result = controller.KupowanieGrobowca(1, 2);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<KupowanieGrobowcaViewModel>(viewResult.Model);
            Assert.Equal(1, model.IdUzytkownik);
            Assert.Equal(2, model.IdGrobowiec);
        }
    }
}
