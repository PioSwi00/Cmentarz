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
using Testowanie.Cmentarz.MVC.Models;

namespace TestMVC
{
    public class UnitTestZmarliController
    {
        [Fact]
        public void Index_ReturnsViewResultWithZmarli()
        {
            var mockZmarlyService = new Mock<IZmarlyService>();
            var zmarliList = new List<Zmarly> { new Zmarly(), new Zmarly() };
            mockZmarlyService.Setup(service => service.PobierzZmarlychZPrzedzialuCzasu(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                             .Returns(zmarliList);

            var controller = new ZmarliController(mockZmarlyService.Object);
            var viewModel = new ZakresDatViewModel
            {
                DataOd = DateTime.Now.AddDays(-30),
                DataDo = DateTime.Now
            };

            var result = controller.Index(viewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Zmarly>>(viewResult.Model);
            Assert.Equal(zmarliList, model);
        }

        [Fact]
        public void ZakresDat_ReturnsViewResultWithZakresDatViewModel()
        {
            var mockZmarlyService = new Mock<IZmarlyService>();
            var controller = new ZmarliController(mockZmarlyService.Object);

            var result = controller.ZakresDat();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ZakresDatViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }
    }
}
