using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using BusinessLogicLayer.Services;
namespace TestBLL
{
    public class OdwiedzajacyServiceTests
    {
        [Fact]
        public void DodajOdwiedzajacego_ShouldAddOdwiedzajacy()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacy = new Odwiedzajacy();

            // Act
            service.DodajOdwiedzajacego(odwiedzajacy);

            // Assert
            unitOfWorkMock.Verify(u => u.Odwiedzajacy.Add(odwiedzajacy), Times.Once);
            unitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void EdytujOdwiedzajacego_ShouldEditOdwiedzajacy()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacy = new Odwiedzajacy { IdOdwiedzajacy = 1 };

            // Act
            service.EdytujOdwiedzajacego(odwiedzajacy);

            // Assert
            unitOfWorkMock.Verify(u => u.Odwiedzajacy.Update(odwiedzajacy), Times.Once);
            unitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectOdwiedzajacy()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var expectedOdwiedzajacy = new Odwiedzajacy { IdOdwiedzajacy = 1 };
            unitOfWorkMock.Setup(u => u.Odwiedzajacy.GetById(1)).Returns(expectedOdwiedzajacy);

            // Act
            var result = service.GetById(1);

            // Assert
            Assert.Equal(expectedOdwiedzajacy, result);
        }

        [Fact]
        public void PobierzWszystkichOdwiedzajacych_ShouldReturnAllOdwiedzajacy()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacyList = new List<Odwiedzajacy> { new Odwiedzajacy(), new Odwiedzajacy() };
            unitOfWorkMock.Setup(u => u.Odwiedzajacy.GetAll()).Returns(odwiedzajacyList);

            // Act
            var result = service.PobierzWszystkichOdwiedzajacych();

            // Assert
            Assert.Equal(odwiedzajacyList, result);
        }

        [Fact]
        public void WyszukajOdwiedzajacych_ShouldReturnMatchingOdwiedzajacy()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacyList = new List<Odwiedzajacy>
        {
            new Odwiedzajacy { IdOdwiedzajacy = 1, Imie = "Jan", Nazwisko = "Kowalski" },
            new Odwiedzajacy { IdOdwiedzajacy = 2, Imie = "Anna", Nazwisko = "Nowak" },
            new Odwiedzajacy { IdOdwiedzajacy = 3, Imie = "Piotr", Nazwisko = "Nowak" }
        };
            unitOfWorkMock.Setup(u => u.Odwiedzajacy.GetAll()).Returns(odwiedzajacyList);

            // Act
            var result = service.WyszukajOdwiedzajacych(2, "Anna", "Nowak");

            // Assert
            Assert.Single(result);
            Assert.Equal(2, result.First().IdOdwiedzajacy);
        }

        [Fact]
        public void WyszukajOdwiedzajacychPoNazwiskuISortujPoImieniu_ShouldReturnMatchingOdwiedzajacySorted()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacyList = new List<Odwiedzajacy>
        {
            new Odwiedzajacy { Imie = "Jan", Nazwisko = "Kowalski" },
            new Odwiedzajacy { Imie = "Anna", Nazwisko = "Nowak" },
            new Odwiedzajacy { Imie = "Piotr", Nazwisko = "Nowak" }
        };
            unitOfWorkMock.Setup(u => u.Odwiedzajacy.GetAll()).Returns(odwiedzajacyList);

            // Act
            var result = service.WyszukajOdwiedzajacychPoNazwiskuISortujPoImieniu("Nowak");

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Anna", result.First().Imie);
            Assert.Equal("Piotr", result.Skip(1).First().Imie);
        }
        [Fact]
        public void WyszukajOdwiedzajacych_ShouldReturnEmptyListWhenNoResults()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new OdwiedzajacyService(unitOfWorkMock.Object);
            var odwiedzajacyList = new List<Odwiedzajacy>(); // Pusta lista odwiedzających
            unitOfWorkMock.Setup(u => u.Odwiedzajacy.GetAll()).Returns(odwiedzajacyList);

            // Act
            var result = service.WyszukajOdwiedzajacych(1, "Jan", "Kowalski");

            // Assert
            Assert.Empty(result);
        }
    }
}