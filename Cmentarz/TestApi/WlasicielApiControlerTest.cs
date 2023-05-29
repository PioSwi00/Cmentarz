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
    public class WlasicielApiControlerTest
    {
        [Fact]
        public void TestGetWlasciciele_ReturnsOKandWlasciciel()
        {
            var mockWlascicielService = new Mock<IWlascicielService>();
            var expectedWlasciciele = new List<Wlasciciel> { new Wlasciciel { IdWlasciciel = 1, Imie = "John", Nazwisko = "Doe" } };
            mockWlascicielService
                .Setup(s => s.GetWlasciciele())
                .Returns(expectedWlasciciele);
            var controller = new WlascicielApiController(mockWlascicielService.Object);

            var result = controller.GetWlasciciele();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualWlasciciele = Assert.IsType<List<Wlasciciel>>(okResult.Value);
            Assert.Equal(expectedWlasciciele, actualWlasciciele);
        }
        [Fact]
        public void TestGetWlascicieleByNazwisko_ReturnsNotFoundResult()
        {
       
            var mockWlascicielService = new Mock<IWlascicielService>();
            var nazwisko = "Hoe";
            mockWlascicielService
                .Setup(s => s.GetByNazwisko(nazwisko))
                .Returns((List<Wlasciciel>)null);


            var controller = new WlascicielApiController(mockWlascicielService.Object);
            var result = controller.GetWlascicieleByNazwisko(nazwisko);

       
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void TestWlascicielGetByOrder_ReturnsOkResultWithWlasciciele()
        {
            var mockWlascicielService = new Mock<IWlascicielService>();
            var sortBy = "Nazwisko";
            var expectedWlasciciele = new List<Wlasciciel>
            {
                new Wlasciciel { IdWlasciciel = 1, Imie = "John", Nazwisko = "Doe" },
                new Wlasciciel { IdWlasciciel = 2, Imie = "Jane", Nazwisko = "Smith" }
            };
            mockWlascicielService
                .Setup(s => s.WlascicielGetByOrder(sortBy))
                .Returns(expectedWlasciciele);
            var controller = new WlascicielApiController(mockWlascicielService.Object);

            var result = controller.WlascicielGetByOrder(sortBy);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualWlasciciele = Assert.IsType<List<Wlasciciel>>(okResult.Value);
            Assert.Equal(expectedWlasciciele, actualWlasciciele);
        }
    }
}
