using Cmentarz.DAL.Repositories;
using Cmentarz.DAL.Models;
using Xunit;
using TestBLL;
using BusinessLogicLayer.Services;
using Moq;
using BusinessLogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestBLL
{
    public class ZmarlyFakeTest
    {
        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            // Arrange
            var repo = new ZmarlyFakeRepo();
            var zmarly = new Zmarly { IdZmarly = 1, Imie = "Jan", Nazwisko = "Kowalski" };
            repo.Add(zmarly);
            

            // Act
            var result = repo.GetById(zmarly.IdZmarly);

            // Assert
            Assert.Equal(zmarly.Imie, result.Imie);
            Assert.Equal(zmarly.Nazwisko, result.Nazwisko);
        }

        [Fact]
        public void TestPobierzZmarlychZPrzedzialuCzasu()
        {
            // Arrange
            var mockZmarliRepo = new Mock<IRepository<Zmarly>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var zmarly1 = new Zmarly { DataSmierci = new DateTime(2022, 1, 1) };
            var zmarly2 = new Zmarly { DataSmierci = new DateTime(2022, 2, 1) };
            var zmarly3 = new Zmarly { DataSmierci = new DateTime(2022, 3, 1) };
            var zmarliList = new List<Zmarly> { zmarly1, zmarly2, zmarly3 };

            mockZmarliRepo.Setup(x => x.GetAll())
                .Returns(zmarliList.AsQueryable());

            mockUnitOfWork.Setup(x => x.Zmarli)
                .Returns(mockZmarliRepo.Object);

            var zmarlyService = new ZmarlyService(mockUnitOfWork.Object);

            // Act
            var result = zmarlyService.PobierzZmarlychZPrzedzialuCzasu(new DateTime(2022, 2, 1), new DateTime(2022, 3, 1));

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(zmarly2, result);
            Assert.Contains(zmarly3, result);
        }
        [Fact]
        public void Delete_ZmarlyIsRemovedAndSaveChangesIsCalled()
        {
            // Arrange
            var zmarly = new Zmarly { IdZmarly = 1, Imie = "Jan", Nazwisko = "Kowalski" };
            var mockContext = new Mock<DbCmentarzContext>();
            var repository = new ZmarlyRepository(mockContext.Object);

            // Act
            repository.Delete(zmarly);

            // Assert
            mockContext.Verify(x => x.SaveChanges(), Times.Once);
            mockContext.Verify(x => x.Zmarli.Remove(zmarly), Times.Once);
        }
        
    }
}
