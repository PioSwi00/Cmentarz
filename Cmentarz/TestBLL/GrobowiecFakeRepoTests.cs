using BusinessLogicLayer.Services;
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
            
            var grobowiec1 = new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "A1", Cena = 1000 };
            var grobowiec2 = new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2, Lokalizacja = "B2", Cena = 2000 };
            var grobowiec3 = new Grobowiec { IdGrobowiec = 3, IdWlasciciel = 3, Lokalizacja = "C3", Cena = 3000 };
            var grobowiecRepo = new GrobowiecFakeRepo();
            grobowiecRepo.Add(grobowiec1);
            grobowiecRepo.Add(grobowiec2);
            grobowiecRepo.Add(grobowiec3);
            var unitOfWork = new UoW(null);
            unitOfWork.Grobowce = grobowiecRepo;
            var grobowiecService = new GrobowiecService(unitOfWork);

            
            var result = grobowiecService.WyszukajGroby(1, 1, "A", 1000);

         
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



    }
}






