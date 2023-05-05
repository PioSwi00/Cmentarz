using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDAL
{
    public class UnitTestUnitOfWork
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<DbCmentarzContext>()
                        .UseInMemoryDatabase("Testowa")
                .Options;
            var dbCmentarzContext = new DbCmentarzContext(options);

            var unitOfWork = new UoW(dbCmentarzContext);

            var grobowiecRepository = unitOfWork.Grobowce;

            Assert.NotNull(grobowiecRepository);
            Assert.IsType<GrobowiecRepository>(grobowiecRepository);
        }
    }
}
