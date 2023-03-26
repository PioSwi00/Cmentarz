using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmentarz.DAL.Repositories
{
    internal class OdwiedzajacyRepository : IRepository<Odwiedzajacy>
    {
        private DbCmentarzContext _context;
        public OdwiedzajacyRepository(DbCmentarzContext context )
        {
            _context = context;
        }
        public Task Add(Odwiedzajacy entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Odwiedzajacy entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Odwiedzajacy>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Odwiedzajacy> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Odwiedzajacy entity)
        {
            throw new NotImplementedException();
        }
    }
}
