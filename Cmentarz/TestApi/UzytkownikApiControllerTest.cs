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

namespace TestApi
{
    public class UzytkownikApiControllerTest
    {
        [Fact]
        public void TestKupowanieGrobowcaAction()
        {
            int idUzytkownik = 1;
            int idGrobowiec = 2;

            Mock<IUzytkownikService> mockUzytkownikService = new Mock<IUzytkownikService>();

            mockUzytkownikService
                .Setup(s => s.KupGrobowiec(idUzytkownik, idGrobowiec))
                .Returns(new Cmentarz.DAL.Models.Grobowiec());

            UzytkownikApiController uzytkownikApiController = new UzytkownikApiController(mockUzytkownikService.Object);

            var result = uzytkownikApiController.KupowanieGrobowca(idUzytkownik, idGrobowiec);

            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]

        public void TestLoginAction_ValidViewModel_ReturnsOkResultWithUserName()
        {

            var viewModel = new LoginViewModel
            {
                Login = "testuser",
                Haslo = "password"
            };

            var user = new Uzytkownik
            {
                Login = viewModel.Login
            };

            Mock<IUzytkownikService> mockUzytkownikService = new Mock<IUzytkownikService>();

            mockUzytkownikService
                .Setup(s => s.Login(viewModel.Login, viewModel.Haslo))
                .Returns(user);

            UzytkownikApiController uzytkownikApiController = new UzytkownikApiController(mockUzytkownikService.Object);

            var result = uzytkownikApiController.Login(viewModel);

     
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<dynamic>(okResult.Value);
            var userName = response.UserName.ToString();
            Assert.Equal(viewModel.Login, userName);
        }
    }
}
