using BusinessLogicLayer.Services;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq.Expressions;

namespace TestBLL
{
    public class AllGrobowiecTests
    {
        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            
            var repo = new GrobowiecFakeRepo();
            var expectedEntity = new Grobowiec { IdGrobowiec = 1 };
            repo.Add(expectedEntity);

           
            var result = repo.GetById(expectedEntity.IdGrobowiec);

           
            Assert.Equal(expectedEntity, result);
        }
        [Fact]
        public void GetAll_Should_Return_All_Entities()
        {
            
            var repo = new GrobowiecFakeRepo();
            var entity1 = new Grobowiec() { IdGrobowiec = 1 };
            var entity2 = new Grobowiec() { IdGrobowiec = 2 };
            repo.Add(entity1);
            repo.Add(entity2);

           
            var result = repo.GetAll();

          
            Assert.Contains(entity1, result);
            Assert.Contains(entity2, result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void PobierzOdwiedzajacychGrobowce_ShouldReturnListOfOdwiedzajacy()
        {
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockGrobowiecRepository = new Mock<IRepository<Grobowiec>>();

          
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(It.IsAny<int>()))
                .Returns(new Grobowiec
                {
                   
                    IdGrobowiec = 1,
                    ListaOdwiedzajacy = new List<Odwiedzajacy>
                    {
                    new Odwiedzajacy { IdOdwiedzajacy = 1, Imie = "Jan" },
                    new Odwiedzajacy { IdOdwiedzajacy = 2, Imie = "Anna" }
                    }
                });

            // Inicjalizacja us³ugi
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);

            // Wywo³anie metody do przetestowania
            var result = grobowiecService.PobierzOdwiedzajacychGrobowce(1);

            // Sprawdzenie oczekiwanych rezultatów
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            // Mo¿esz dodaæ wiêcej asercji, w zale¿noœci od Twoich oczekiwañ
            var expectedNames = new[] { "Jan", "Anna" };
            Assert.True(result.All(odwiedzajacy => expectedNames.Contains(odwiedzajacy.Imie)));
        }
        [Fact]
        public void PobierzWszystkieGrobowce_ShouldReturnAllEntities()
        {
          
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

        [Fact]
        public void WyszukajGroby_ReturnsMatchingGrobowce_WhenMatchingGrobowceExist()
        {
            
            var grobowiec1 = new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "A1", Cena = 1000,Sektor="A" };
            var grobowiec2 = new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2, Lokalizacja = "B2", Cena = 2000, Sektor = "A" };
            var grobowiec3 = new Grobowiec { IdGrobowiec = 3, IdWlasciciel = 3, Lokalizacja = "C3", Cena = 3000, Sektor = "A" };
            var grobowiecRepo = new GrobowiecFakeRepo();
            grobowiecRepo.Add(grobowiec1);
            grobowiecRepo.Add(grobowiec2);
            grobowiecRepo.Add(grobowiec3);
            var unitOfWork = new UoW(null);
            unitOfWork.Grobowce = grobowiecRepo;
            var grobowiecService = new GrobowiecService(unitOfWork);

            
            var result = grobowiecService.WyszukajGroby(1, 1, "A", 1000,"A");

         
            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal(grobowiec1, item)
            );
        }





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
                Imie = "X",
                Nazwisko = "Xxxx",
                DataUrodzenia = new DateTime(2000, 6, 13),
                DataSmierci = new DateTime(2018, 8, 13),
                GrobowiecID = grobowiecTest.IdGrobowiec,
                //Grobowiec = grobowiecTest
            };

            grobowceRepository.AddRange(new List<Grobowiec> { grobowiecTest });
            grobowceService.DodajZmarlegoDoGrobowca(1, zmarlyTest);

            Assert.Equal(1, grobowceRepository.GetAll().Count());
        }
        [Fact]
        public void DodajZmarlegoDoGrobowca_ValidGrobowca_AddsZmarly()
        {
            // Arrange
            int idGrobowca = 1;
            var grobowiec = new Grobowiec { IdGrobowiec = idGrobowca, Zmarli = new List<Zmarly>() };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(idGrobowca))
                .Returns(grobowiec);
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);
            var zmarly = new Zmarly();

            // Act
            grobowiecService.DodajZmarlegoDoGrobowca(idGrobowca, zmarly);

            // Assert
            Assert.Single(grobowiec.Zmarli);
        }
        [Fact]
        public void TestIloscOdwiedzajacychMoq()
        {
           
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

         
            int actualCount = grobowiecService.IloscOdwiedzajacych(grobowiecId);
            Assert.Equal(expectedCount, actualCount);
        }
        [Fact]

        //spy

        public void IloscOdwiedzajacych_Should_Call_GetById_Method_And_Return_Correct_Count()
        {
            
            int expectedCount = 3;
            int grobowiecId = 1;

            var odwiedzajacyList = new List<Odwiedzajacy>
            {
                new Odwiedzajacy(),
                new Odwiedzajacy(),
                new Odwiedzajacy()
            };

            var mockRepo = new Mock<IRepository<Grobowiec>>();
            var spyRepo = Mock.Of<IRepository<Grobowiec>>(x => x.GetById(grobowiecId) == new Grobowiec { ListaOdwiedzajacy = odwiedzajacyList });
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Grobowce).Returns(spyRepo);

            var grobowiecService = new GrobowiecService(unitOfWork.Object);

          
            int actualCount = grobowiecService.IloscOdwiedzajacych(grobowiecId);

          
            Assert.Equal(expectedCount, actualCount);
            Mock.Get(spyRepo).Verify(x => x.GetById(grobowiecId), Times.Once);
        }


        [Fact]
        public void PobierzWolneGroby_Should_Return_Unoccupied_Grobowce()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Grobowiec>>();

            // Przygotowanie przyk³adowych grobów, z których niektóre s¹ zajête
            var unoccupiedGrobowiec = new Grobowiec { IdGrobowiec = 1, CzyZajety = false };
            var occupiedGrobowiec = new Grobowiec { IdGrobowiec = 2, CzyZajety = true };

            var grobowceList = new List<Grobowiec>
            {
                unoccupiedGrobowiec,
                occupiedGrobowiec
            };

            // Konfiguracja repozytorium i unitOfWork
            mockRepository.Setup(m => m.GetAll()).Returns(grobowceList);
            unitOfWork.Setup(u => u.Grobowce).Returns(mockRepository.Object);

            var grobowiecService = new GrobowiecService(unitOfWork.Object);

            // Act
            var result = grobowiecService.PobierzWolneGroby();

            // Assert
            Assert.Single(result); // Oczekujemy, ¿e tylko jeden grobowiec nie bêdzie zajêty
            Assert.Equal(unoccupiedGrobowiec, result.First()); // Sprawdzamy, czy to jest ten grobowiec
        }

        [Fact]
        public void PobierzWszystkieGrobowce_ReturnsAllGrobowce()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetAll())
                .Returns(new List<Grobowiec>
                {
                 new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1,Lokalizacja="Tak",Cena=10 },
                new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2,Lokalizacja="Tak",Cena=10 }
                });
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);

            // Act
            var result = grobowiecService.PobierzWszystkieGrobowce();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void GetGrobowceFilteredById_ValidId_ReturnsGrobowiec()
        {
            // Arrange
            int id = 1;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(id))
                .Returns(new Grobowiec { IdGrobowiec = id });
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);

            // Act
            var result = grobowiecService.GetGrobowceFilteredById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.IdGrobowiec);
        }
        [Fact]
    
        public void GetById_ShouldThrowExceptionWhenGrobowiecNotFound()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new GrobowiecService(unitOfWorkMock.Object);

            unitOfWorkMock.Setup(u => u.Grobowce.FirstOrDefault(It.IsAny<Expression<Func<Grobowiec, bool>>>()))
                .Returns((Grobowiec)null);

            // Act i Assert
            Assert.Throws<ArgumentException>(() => service.GetById(1).Result); // Uwaga: u¿ywamy .Result, poniewa¿ metoda jest asynchroniczna
        }

    }
}






