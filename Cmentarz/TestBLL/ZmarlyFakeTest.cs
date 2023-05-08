using Cmentarz.DAL.Repositories;
using Cmentarz.DAL.Models;
using Xunit;
using TestBLL;
using BusinessLogicLayer.Services;
using Moq;

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
        

    }
}
