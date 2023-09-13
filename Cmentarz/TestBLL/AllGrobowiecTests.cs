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
        public void DodajZmarlegoDoGrobowca_ValidGrobowca_AddsZmarly()
        {

            var grobowiec = new Grobowiec { IdGrobowiec = 1, Zmarli = new List<Zmarly>() };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(It.IsAny<int>()))
                .Returns(grobowiec);
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);
            var zmarly = new Zmarly();


            grobowiecService.DodajZmarlegoDoGrobowca(1, zmarly);


            Assert.Single(grobowiec.Zmarli);
            Assert.Contains(zmarly, grobowiec.Zmarli);
            mockUnitOfWork.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void DodajZmarlegoDoGrobowca_ThrowsException_When_Grobowiec_Not_Found()
        {

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(It.IsAny<int>()))
                .Returns((Grobowiec)null);
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);


            Assert.Throws<ArgumentException>(() => grobowiecService.DodajZmarlegoDoGrobowca(1, new Zmarly()));
        }

        [Fact]
        public void IloscOdwiedzajacych_Should_Return_Correct_Count()
        {

            int expectedCount = 3;
            int grobowiecId = 1;
            var odwiedzajacyList = new List<Odwiedzajacy>
        {
            new Odwiedzajacy(),
            new Odwiedzajacy(),
            new Odwiedzajacy()
        };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(grobowiecId))
                .Returns(new Grobowiec { ListaOdwiedzajacy = odwiedzajacyList });
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);


            int actualCount = grobowiecService.IloscOdwiedzajacych(grobowiecId);


            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void PobierzWolneGroby_Should_Return_Unoccupied_Grobowce()
        {

            var unoccupiedGrobowiec = new Grobowiec { IdGrobowiec = 1, CzyZajety = false };
            var occupiedGrobowiec = new Grobowiec { IdGrobowiec = 2, CzyZajety = true };
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Grobowiec>>();
            mockRepository.Setup(m => m.GetAll())
                .Returns(new List<Grobowiec> { unoccupiedGrobowiec, occupiedGrobowiec });
            unitOfWorkMock.Setup(u => u.Grobowce).Returns(mockRepository.Object);
            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzWolneGroby();


            Assert.Single(result);
            Assert.Equal(unoccupiedGrobowiec, result.First());
        }

        [Fact]
        public void PobierzWszystkieGrobowce_Should_Return_All_Grobowce()
        {

            var expectedEntities = new List<Grobowiec>
        {
            new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "Tak", Cena = 10 },
            new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2, Lokalizacja = "Tak", Cena = 10 }
        };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetAll()).Returns(expectedEntities);
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);


            var result = grobowiecService.PobierzWszystkieGrobowce();


            Assert.Equal(expectedEntities, result);
        }

        [Fact]
        public void GetGrobowceFilteredById_ValidId_ReturnsGrobowiec()
        {

            int id = 1;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Grobowce.GetById(id))
                .Returns(new Grobowiec { IdGrobowiec = id });
            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);


            var result = grobowiecService.GetGrobowceFilteredById(id);


            Assert.NotNull(result);
            Assert.Equal(id, result.IdGrobowiec);
        }

        [Fact]
        public void GetById_ShouldThrowExceptionWhenGrobowiecNotFound()
        {

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var service = new GrobowiecService(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(u => u.Grobowce.FirstOrDefault(It.IsAny<Expression<Func<Grobowiec, bool>>>()))
                 .Returns((Grobowiec)null);
            Assert.Throws<ArgumentException>(() => service.GetById(1).Result);
        }
        [Fact]
        public void PobierzGrobyWlasciciela_Should_Return_Grobowce_Of_Owner()
        {

            int ownerId = 1;
            var ownerGrobowce = new List<Grobowiec>
            {
                new Grobowiec { IdGrobowiec = 1, IdWlasciciel = ownerId },
                new Grobowiec { IdGrobowiec = 2, IdWlasciciel = ownerId }
            };

            var otherGrobowce = new List<Grobowiec>
            {
                new Grobowiec { IdGrobowiec = 3, IdWlasciciel = 2 },
                new Grobowiec { IdGrobowiec = 4, IdWlasciciel = 3 }
            };

            var allGrobowce = ownerGrobowce.Concat(otherGrobowce).ToList();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Grobowiec>>();
            mockRepository.Setup(m => m.GetAll()).Returns(allGrobowce);
            unitOfWorkMock.Setup(u => u.Grobowce).Returns(mockRepository.Object);

            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);

            var result = grobowiecService.PobierzGrobyWlasciciela(ownerId);


            Assert.Equal(ownerGrobowce, result);
        }

        [Fact]
        public void DodajOdwiedzajacegoDoGrobowca_Should_Add_Odwiedzajacy_To_Grobowiec()
        {

            int grobowiecId = 1;
            int odwiedzajacyId = 1;

            var grobowiec = new Grobowiec { IdGrobowiec = grobowiecId, ListaOdwiedzajacy = new List<Odwiedzajacy>() };
            var odwiedzajacy = new Odwiedzajacy { IdOdwiedzajacy = odwiedzajacyId };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId)).Returns(grobowiec);

            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            grobowiecService.DodajOdwiedzajacegoDoGrobowca(grobowiecId, odwiedzajacyId);


            Assert.Single(grobowiec.ListaOdwiedzajacy);
            Assert.Contains(odwiedzajacy, grobowiec.ListaOdwiedzajacy);
            unitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void UsunOdwiedzajacegoZGrobowca_Should_Remove_Odwiedzajacy_From_Grobowiec()
        {

            int grobowiecId = 1;
            int odwiedzajacyId = 1;

            var odwiedzajacy = new Odwiedzajacy { IdOdwiedzajacy = odwiedzajacyId };
            var grobowiec = new Grobowiec { IdGrobowiec = grobowiecId, ListaOdwiedzajacy = new List<Odwiedzajacy> { odwiedzajacy } };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId)).Returns(grobowiec);

            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            grobowiecService.UsunOdwiedzajacegoZGrobowca(grobowiecId, odwiedzajacyId);


            Assert.Empty(grobowiec.ListaOdwiedzajacy);
            unitOfWorkMock.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void PobierzOdwiedzajacychGrobowce_Should_Return_List_Of_Odwiedzajacy()
        {
            int grobowiecId = 1;
            var odwiedzajacyList = new List<Odwiedzajacy>
            {
                new Odwiedzajacy { IdOdwiedzajacy = 1, Imie = "Jan" },
                new Odwiedzajacy { IdOdwiedzajacy = 2, Imie = "Anna" }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId))
                .Returns(new Grobowiec
                {
                    IdGrobowiec = grobowiecId,
                    ListaOdwiedzajacy = odwiedzajacyList
                });

            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzOdwiedzajacychGrobowce(grobowiecId);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            var expectedNames = new[] { "Jan", "Anna" };
            Assert.True(result.All(odwiedzajacy => expectedNames.Contains(odwiedzajacy.Imie)));
        }

        [Fact]
        public void WyszukajGroby_Should_Return_Matching_Grobowce()
        {

            var grobowiec1 = new Grobowiec { IdGrobowiec = 1, IdWlasciciel = 1, Lokalizacja = "A1", Cena = 1000, Sektor = "A" };
            var grobowiec2 = new Grobowiec { IdGrobowiec = 2, IdWlasciciel = 2, Lokalizacja = "B2", Cena = 2000, Sektor = "A" };
            var grobowiec3 = new Grobowiec { IdGrobowiec = 3, IdWlasciciel = 3, Lokalizacja = "C3", Cena = 3000, Sektor = "A" };
            var grobowiecRepo = new GrobowiecFakeRepo();
            grobowiecRepo.Add(grobowiec1);
            grobowiecRepo.Add(grobowiec2);
            grobowiecRepo.Add(grobowiec3);
            var unitOfWork = new UoW(null);
            unitOfWork.Grobowce = grobowiecRepo;
            var grobowiecService = new GrobowiecService(unitOfWork);


            var result = grobowiecService.WyszukajGroby(1, 1, "A", 1000, "A");


            Assert.NotNull(result);
            Assert.Collection(result, item => Assert.Equal(grobowiec1, item));
        }
        [Fact]
        public void DodajGrobowiec_Should_Add_New_Grobowiec()
        {

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Grobowiec>>();
            mockUnitOfWork.Setup(u => u.Grobowce).Returns(mockRepository.Object);

            var grobowiecService = new GrobowiecService(mockUnitOfWork.Object);

            var nowyGrobowiec = new Grobowiec { IdGrobowiec = 1, Lokalizacja = "Nowy grobowiec", Cena = 1000, CzyZajety = false };


            grobowiecService.DodajGrobowiec(nowyGrobowiec);


            mockRepository.Verify(r => r.Add(It.IsAny<Grobowiec>()), Times.Once);
            mockUnitOfWork.Verify(u => u.Save(), Times.Once);
        }


        [Fact]
        public void PobierzGrobowceZajete_Should_Return_Occupied_Grobowce()
        {

            var occupiedGrobowiec1 = new Grobowiec { IdGrobowiec = 1, CzyZajety = true };
            var occupiedGrobowiec2 = new Grobowiec { IdGrobowiec = 2, CzyZajety = true };
            var unoccupiedGrobowiec = new Grobowiec { IdGrobowiec = 3, CzyZajety = false };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var mockRepository = new Mock<IRepository<Grobowiec>>();
            mockRepository.Setup(m => m.GetAll()).Returns(new List<Grobowiec> { occupiedGrobowiec1, occupiedGrobowiec2, unoccupiedGrobowiec });
            unitOfWorkMock.Setup(u => u.Grobowce).Returns(mockRepository.Object);

            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzZajeteGroby();


            Assert.Equal(2, result.Count());
            Assert.Contains(occupiedGrobowiec1, result);
            Assert.Contains(occupiedGrobowiec2, result);
        }
        [Fact]
        public void PobierzZmarlychWGrobie_Should_Return_Zmarlych_When_Grobowiec_Exists()
        {

            int grobowiecId = 1;
            var zmarliList = new List<Zmarly>
            {
                new Zmarly { IdZmarly = 1, Imie = "Jan" },
                new Zmarly { IdZmarly = 2, Imie = "Anna" }
            };

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId))
                .Returns(new Grobowiec { IdGrobowiec = grobowiecId, Zmarli = zmarliList });
            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzZmarlychWGrobie(grobowiecId);


            Assert.NotNull(result);
            Assert.Equal(zmarliList, result);
        }

        [Fact]
        public void PobierzZmarlychWGrobie_Should_Return_Empty_List_When_Grobowiec_Does_Not_Exist()
        {

            int grobowiecId = 1;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId))
                .Returns((Grobowiec)null);
            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzZmarlychWGrobie(grobowiecId);


            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void PobierzZmarlychWGrobie_Should_Return_Empty_List_When_Grobowiec_Has_No_Zmarli()
        {

            int grobowiecId = 1;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Grobowce.GetById(grobowiecId))
                .Returns(new Grobowiec { IdGrobowiec = grobowiecId, Zmarli = null });
            var grobowiecService = new GrobowiecService(unitOfWorkMock.Object);


            var result = grobowiecService.PobierzZmarlychWGrobie(grobowiecId);


            Assert.NotNull(result);
            Assert.Empty(result);
        }


    }
}






