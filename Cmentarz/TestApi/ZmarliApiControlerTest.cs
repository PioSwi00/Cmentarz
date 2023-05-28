using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testowanie.Cmenatrz.MVC.Controllers;
using Testowanie.Cmentarz.MVC.Models;

namespace TestApi
{
    public class ZmarliApiControllerTests
    {
        [Fact]
        public void ZakresDat_Should_Return_ZakresDatViewModel()
        {
         
            var zmarlyServiceMock = new Mock<IZmarlyService>();
            var controller = new ZmarliApiController(zmarlyServiceMock.Object);

           
            var result = controller.ZakresDat();
  
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsType<ZakresDatViewModel>(okResult.Value);
        }

        [Fact]
        public void Index_Should_Return_List_Of_Zmarli()
        {
            
            var zmarlyServiceMock = new Mock<IZmarlyService>();
            var controller = new ZmarliApiController(zmarlyServiceMock.Object);
            var viewModel = new ZakresDatViewModel
            {
                DataOd = DateTime.Now.AddDays(-30),
                DataDo = DateTime.Now
            };
            var expectedZmarli = new List<Zmarly>();  // wsm wypelnic ta liste mozna

            zmarlyServiceMock.Setup(x => x.PobierzZmarlychZPrzedzialuCzasu(viewModel.DataOd, viewModel.DataDo))
                             .Returns(expectedZmarli);

            
            var result = controller.Index(viewModel);

            
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedZmarli, okResult.Value);
        }
    }
}

