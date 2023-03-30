using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;
using ContosoUniversity.DAL;

namespace Cmentarz.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private DbCmentarzContext context;
        private GenericRepository<Grobowiec> grobowce;
        //private GenericRepository<Course> courseRepository;

        public GenericRepository<Grobowiec> Grobowce
        {
            get
            {

                if (this.grobowce == null)
                {
                    this.grobowce = new GenericRepository<Grobowiec>(context);
                }
                return Grobowce;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
