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
    public class GrobowceApiControllerTest
    {
        [Fact]
        public void TestGetGrobowccFilteredById_ExistingId_ReturnsOk()
        {
          
            var mockGrobowiecService = new Mock<IGrobowiecService>();
            var expectedGrobowiec = new Grobowiec { IdGrobowiec= 1 };
            mockGrobowiecService
                .Setup(s => s.GetGrobowceFilteredById(It.IsAny<int>()))
                .Returns(expectedGrobowiec);
            var controller = new GrobowiecApiController(mockGrobowiecService.Object);

            var result = controller.GetGrobowceFilteredById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualGrobowiec = Assert.IsType<Grobowiec>(okResult.Value);
            Assert.Equal(expectedGrobowiec.IdGrobowiec, actualGrobowiec.IdGrobowiec);
        }

        [Fact]
        public void TestGetGrobowceFilteredById_NonExistingId_ReturnsNotFoundResult()
        {
            var mockGrobowiecService = new Mock<IGrobowiecService>();
            mockGrobowiecService
                .Setup(s => s.GetGrobowceFilteredById(It.IsAny<int>()))
                .Returns((Grobowiec)null);
            var controller = new GrobowiecApiController(mockGrobowiecService.Object);

            var result = controller.GetGrobowceFilteredById(1);

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void TestGetAllGrobowce_ReturnList()
        {
            
            var mockGrobowiecService = new Mock<IGrobowiecService>();
            var expectedGrobowce = new List<Grobowiec>
            {
                new Grobowiec { IdGrobowiec = 1},
                new Grobowiec { IdGrobowiec=2}
            };
            mockGrobowiecService
                .Setup(s => s.PobierzWszystkieGrobowce())
                .Returns(expectedGrobowce);
            var controller = new GrobowiecApiController(mockGrobowiecService.Object);

            var result = controller.GetAllGrobowce();
            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualGrobowce = Assert.IsType<List<Grobowiec>>(okResult.Value);

            Assert.Equal(expectedGrobowce.Count, actualGrobowce.Count);

            for (int i = 0; i < expectedGrobowce.Count; i++)
            {
                Assert.Equal(expectedGrobowce[i].IdGrobowiec, actualGrobowce[i].IdGrobowiec);
            }  
        }
        [Fact]
        public void TestLiczbaStudentowAction()
        {
           var mock = new Mock<IGrobowiecService>();
           
            mock.Setup(s => s.IloscOdwiedzajacych(It.IsAny<int>()))
               .Returns(5);

            GrobowiecApiController grobowceApiController = new GrobowiecApiController(mock.Object);
            var result = grobowceApiController.IloscOdwiedzajacych(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualCount = Assert.IsType<int>(okResult.Value);
            Assert.Equal(5, actualCount);
        }



    }
}
