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
public void PobierzZmarlychZPrzedzialuCzasu_Should_Return_Zmarli_In_Range()
        {
            // Arrange
            var dataOd = new DateTime(2000, 1, 1);
            var dataDo = new DateTime(2020, 1, 1);
            var dataOd2 = new DateTime(1990, 1, 1);
            var dataDo2 = new DateTime(1999, 12, 31);
            var zmarly1 = new Zmarly { DataSmierci = new DateTime(2010, 5, 5) };
            var zmarly2 = new Zmarly { DataSmierci = new DateTime(2015, 3, 10) };
            var zmarly3 = new Zmarly { DataSmierci = new DateTime(2025, 2, 20) };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zmarli.GetAll()).Returns(new List<Zmarly> { zmarly1, zmarly2, zmarly3 });
            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            // Act
            var result = zmarlyService.PobierzZmarlychZPrzedzialuCzasu(dataOd, dataDo);
            var result2 = zmarlyService.PobierzZmarlychZPrzedzialuCzasu(dataOd2, dataDo2);

            // Assert
            Assert.Contains(zmarly1, result);
            Assert.Contains(zmarly2, result);
            Assert.DoesNotContain(zmarly3, result);
            Assert.Empty(result2);
        }

        [Fact]
        public void PobierzZmarlychPosortowanychWedlugWieku_Should_Return_Sorted_Zmarli()
        {
            // Arrange
            var zmarly1 = new Zmarly { DataUrodzenia = new DateTime(1990, 1, 1) };
            var zmarly2 = new Zmarly { DataUrodzenia = new DateTime(1980, 2, 10) };
            var zmarly3 = new Zmarly { DataUrodzenia = new DateTime(2000, 3, 20) };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zmarli.GetAll()).Returns(new List<Zmarly> { zmarly1, zmarly2, zmarly3 });
            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            // Act
            var result = zmarlyService.PobierzZmarlychPosortowanychWedlugWieku().ToList();

            // Assert
            Assert.Equal(zmarly2, result[0]);
            Assert.Equal(zmarly1, result[1]);
            Assert.Equal(zmarly3, result[2]);
        }

        [Fact]
        public void PobierzWszystkichZmarlych_Should_Return_All_Zmarli()
        {
            // Arrange
            var zmarly1 = new Zmarly();
            var zmarly2 = new Zmarly();
            var zmarly3 = new Zmarly();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Zmarli.GetAll()).Returns(new List<Zmarly> { zmarly1, zmarly2, zmarly3 });
            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            // Act
            var result = zmarlyService.PobierzWszystkichZmarlych().ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(zmarly1, result);
            Assert.Contains(zmarly2, result);
            Assert.Contains(zmarly3, result);
        }

        [Fact]
        public void DodajZmarlego_Should_Add_Zmarly()
        {
            var zmarly = new Zmarly();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            zmarlyService.DodajZmarlego(zmarly);

            mockUnitOfWork.Verify(u => u.Zmarli.Add(It.IsAny<Zmarly>()), Times.Once);
            mockUnitOfWork.Verify(u => u.Zmarli.SaveChanges(zmarly), Times.Once);
        }

        [Fact]
        public void DodajZmarlego_Should_Throw_Exception_When_Null_Zmarly()
        {
            Zmarly zmarly = null;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            Assert.Throws<ArgumentNullException>(() => zmarlyService.DodajZmarlego(zmarly));
        }

       
    }
}

