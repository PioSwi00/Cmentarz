using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cmentarz.DAL.Models;
using System.Threading.Tasks;

namespace Cmentarz.DAL
{
    internal class CmentarzContextFactory : IDesignTimeDbContextFactory<DbCmentarzContext>
    {
        public DbCmentarzContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<DbCmentarzContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cmentarz;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new DbCmentarzContext(optionsBuilder.Options);
        }
    }
}
