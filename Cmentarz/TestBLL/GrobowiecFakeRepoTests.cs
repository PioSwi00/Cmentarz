using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestBLL
{
    public class GrobowiecFakeRepoTests
    {
        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            // Arrange
            var repo = new GrobowiecFakeRepo();
            var expectedEntity = new Grobowiec { IdGrobowiec = 1 };
            repo.Add(expectedEntity);

            // Act
            var result = repo.GetById(expectedEntity.IdGrobowiec);

            // Assert
            Assert.Equal(expectedEntity, result);
        }
        [Fact]
        public void GetAll_Should_Return_All_Entities()
        {
            // Arrange
            var repo = new GrobowiecFakeRepo();
            var entity1 = new Grobowiec() { IdGrobowiec = 1 };
            var entity2 = new Grobowiec() { IdGrobowiec = 2 };
            repo.Add(entity1);
            repo.Add(entity2);

            // Act
            var result = repo.GetAll();

            // Assert
            Assert.Contains(entity1, result);
            Assert.Contains(entity2, result);
            Assert.Equal(2, result.Count());
        }
    }




}

