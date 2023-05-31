using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testowanie.Cmentarz.MVC.Controllers;

namespace TestMVC
{
    public class UnitTestOdwiedzajacyController
    {
        [Fact]
        public void WyszukajOdwiedzajacych_Post_ReturnsViewWithOdwiedzajacy()
        {
            var odwiedzajacyServiceMock = new Mock<IOdwiedzajacyService>();
            var controller = new OdwiedzajacyController(odwiedzajacyServiceMock.Object);
            var odwiedzajacyList = new List<Odwiedzajacy>
            {
                new Odwiedzajacy { IdOdwiedzajacy = 1, Imie = "Jan", Nazwisko = "Kowalski" }
            };

            odwiedzajacyServiceMock.Setup(s => s.WyszukajOdwiedzajacych(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(odwiedzajacyList);

            var result = controller.WyszukajOdwiedzajacych(1, "Jan", "Kowalski");

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Odwiedzajacy>>(viewResult.Model);
            Assert.Equal(odwiedzajacyList, model);
        }

    }
}
