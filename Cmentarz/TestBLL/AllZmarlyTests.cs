using BusinessLogicLayer.Services;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBLL
{
    public class AllZmarlyTests
    {
        [Fact]
        public void PobierzZmarlychZPrzedzialuCzasu_ShouldReturnZmarlyList()
        {
            // Arrange
            var dataOd = DateTime.Now.AddYears(-10);
            var dataDo = DateTime.Now;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var zmarli = new List<Zmarly>
        {
            new Zmarly { DataSmierci = DateTime.Now.AddYears(-5) },
            new Zmarly { DataSmierci = DateTime.Now.AddYears(-2) },
            new Zmarly { DataSmierci = DateTime.Now.AddYears(-7) }
        };
            unitOfWorkMock.Setup(u => u.Zmarli.GetAll()).Returns(zmarli);
            var service = new ZmarlyService(unitOfWorkMock.Object);

            // Act
            var result = service.PobierzZmarlychZPrzedzialuCzasu(dataOd, dataDo);

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void PobierzZmarlychPosortowanychWedlugWieku_ShouldReturnZmarlyListOrderedByAge()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var zmarli = new List<Zmarly>
        {
            new Zmarly { DataUrodzenia = DateTime.Now.AddYears(-40) },
            new Zmarly { DataUrodzenia = DateTime.Now.AddYears(-60) },
            new Zmarly { DataUrodzenia = DateTime.Now.AddYears(-30) }
        };
            unitOfWorkMock.Setup(u => u.Zmarli.GetAll()).Returns(zmarli);
            var service = new ZmarlyService(unitOfWorkMock.Object);

            // Act
            var result = service.PobierzZmarlychPosortowanychWedlugWieku();

            // Assert
            Assert.Equal(zmarli.OrderBy(z => DateTime.Now.Year - z.DataUrodzenia.Year), result);
        }

        [Fact]
        public void PobierzWszystkichZmarlych_ShouldReturnAllZmarly()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var zmarli = new List<Zmarly>
        {
            new Zmarly(),
            new Zmarly(),
            new Zmarly()
        };
            unitOfWorkMock.Setup(u => u.Zmarli.GetAll()).Returns(zmarli);
            var service = new ZmarlyService(unitOfWorkMock.Object);

            // Act
            var result = service.PobierzWszystkichZmarlych();

            // Assert
            Assert.Equal(zmarli, result);
        }

        [Fact]
        public void DodajZmarlego_ShouldAddZmarlyToUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var zmarly = new Zmarly();
            var service = new ZmarlyService(unitOfWorkMock.Object);

            // Act
            service.DodajZmarlego(zmarly);

            // Assert
            unitOfWorkMock.Verify(u => u.Zmarli.Add(zmarly), Times.Once);
            unitOfWorkMock.Verify(u => u.Zmarli.SaveChanges(zmarly), Times.Once);
        }
    }
}
