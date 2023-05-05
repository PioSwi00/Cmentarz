using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectDAL
{
    public class UnitTestOfGrobowiecRepo
    {
        [Fact]
        public void TestGetGrobowce()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<DbCmentarzContext>()
                .UseInMemoryDatabase("Testowa")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            using (var inMemoryDbContext = new DbCmentarzContext(options))
            {
                GrobowiecRepository grobowiecRepository = new GrobowiecRepository(inMemoryDbContext);

                Assert.Empty(grobowiecRepository.GetAll());
                var grob = new Grobowiec { IdWlasciciel = 2, Lokalizacja = "Orzesze", Cena = 2000, CzyZajety = false, ListaOdwiedzajacy = null, Zmarli = null };
                grobowiecRepository.Add(grob);
                grobowiecRepository.SaveChanges(grob);
                Assert.Equal(1, grobowiecRepository.GetAll().Count());
            }
        }
    }
}
