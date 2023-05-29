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

namespace TestApi
{
    public class OdwiedzajacyApiTest
    {
        [Fact]
        public void WyszukajOdwiedzajacychByQuery_ReturnsOkResultWithSearchResults()
        {
            // Arrange
            var odwiedzajacyServiceMock = new Mock<IOdwiedzajacyService>();
            var expectedResult = new List<Odwiedzajacy>
            {
                new Odwiedzajacy { IdOdwiedzajacy = 1, Imie = "Motyka", Nazwisko = "Hoe" },
                new Odwiedzajacy { IdOdwiedzajacy = 2, Imie = "Drill", Nazwisko = "Świder" }
            };
            odwiedzajacyServiceMock.Setup(s => s.WyszukajOdwiedzajacych(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedResult);

            var controller = new OdwiedzajacyApiController(odwiedzajacyServiceMock.Object);

            // Act
            var result = controller.WyszukajOdwiedzajacychByQuery(1, "Motyka", "Hoe") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var searchResults = result.Value as IEnumerable<object>;
            Assert.NotNull(searchResults);
            Assert.Equal(2, searchResults.Count());

            var firstResult = searchResults.First();
            Assert.Equal(1, firstResult.GetType().GetProperty("Id").GetValue(firstResult, null));
            Assert.Equal("Motyka", firstResult.GetType().GetProperty("Imie").GetValue(firstResult, null));
            Assert.Equal("Hoe", firstResult.GetType().GetProperty("Nazwisko").GetValue(firstResult, null));
        }

        [Fact]
        public void WyszukajOdwiedzajacychByQuery_ReturnsNoContentResult()
        {
            // Arrange
            var odwiedzajacyServiceMock = new Mock<IOdwiedzajacyService>();
            odwiedzajacyServiceMock.Setup(s => s.WyszukajOdwiedzajacych(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<Odwiedzajacy>());

            var controller = new OdwiedzajacyApiController(odwiedzajacyServiceMock.Object);

            // Act
            var result = controller.WyszukajOdwiedzajacychByQuery(1, "John", "Doe") as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);
        }
    }
}

