using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        /// 
        /// Wsm to test dla service wiec chyba git ale chyba niekoniecznie tu ma zostac 
        /// 
        [Fact]
        public void PobierzWszystkieGrobowce_ShouldReturnAllEntities()
        {
            // Arrange
            var expectedEntities = new List<Grobowiec>
            {
                new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1,Lokalizacja="Tak",Cena=10 },
                new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2,Lokalizacja="Tak",Cena=10 }
            };

            var mockRepository = new Mock<IRepository<Grobowiec>>();
            mockRepository.Setup(m => m.GetAll()).Returns(expectedEntities);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce).Returns(mockRepository.Object);

            var grobowceBLL = new GrobowiecService(mockUnitOfWork.Object);
         
         
            var result = grobowceBLL.PobierzWszystkieGrobowce();

         
            Assert.Equal(expectedEntities, result);
        }
        /*[Fact]
        public void StubExample()
        {
            var mockGrobowiecRepo = new Mock<IRepository<Grobowiec>>();
            mockGrobowiecRepo.Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns(Mock.Of<Grobowiec>(g => g.IdGrobowiec == 1 && g.IdWlasciciel == 1 && g.Lokalizacja == "Tak" && g.Cena == 10)); // Stub

            var grobowiecService = new GrobowiecService(new UoW(mockGrobowiecRepo.Object));

            var result = grobowiecService.GetGrobowceFilteredById(1);

            result.IdWlasciciel.Should().Be(1, "because the IdWlasciciel property should have been set to 1");

        }*/

        [Fact]
        public void TestDodajZmarlegoDoGrobowca()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DbCmentarzContext>()
                .UseInternalServiceProvider(serviceProvider)
                .UseInMemoryDatabase("Testowa")
                .Options;

            var dbCmentarzContext = new DbCmentarzContext(options);
            var unitOfWork = new UoW(dbCmentarzContext);
            var grobowceRepository = new GrobowiecRepository(dbCmentarzContext);
            var grobowceService = new GrobowiecService(unitOfWork);
            var grobowiecTest = new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "Tak", Cena = 10 };
            var zmarlyTest = new Zmarly
            {
                Imie = "Jarek",
                Nazwisko = "Lepich",
                DataUrodzenia = new DateTime(2000, 6, 13),
                DataSmierci = new DateTime(2018, 8, 13),
                GrobowiecID = grobowiecTest.IdGrobowiec,
                Grobowiec = grobowiecTest
            };

            grobowceRepository.AddRange(new List<Grobowiec> { grobowiecTest });
            grobowceService.DodajZmarlegoDoGrobowca(1, zmarlyTest);

            Assert.Equal(1, grobowceRepository.GetAll().Count());
        }

        [Fact]
        public void TestIloscOdwiedzajacychMoq()
        {
            // Arrange
            int expectedCount = 3;
            int grobowiecId = 1;

            var odwiedzajacyList = new List<Odwiedzajacy>
    {
        new Odwiedzajacy(),
        new Odwiedzajacy(),
        new Odwiedzajacy()
    };

            Mock<IRepository<Grobowiec>> mockGrobowceRepo = new Mock<IRepository<Grobowiec>>();
            mockGrobowceRepo.Setup(x => x.GetById(grobowiecId))
                .Returns(new Grobowiec
                {
                    ListaOdwiedzajacy = odwiedzajacyList
                });

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Grobowce).Returns(mockGrobowceRepo.Object);

            var grobowiecService = new GrobowiecService(unitOfWork.Object);

            // Act
            int actualCount = grobowiecService.IloscOdwiedzajacych(grobowiecId);

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }


    }

}

