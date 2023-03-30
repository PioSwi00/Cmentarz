using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cmentarz.DAL.Models;


namespace Cmentarz.DAL.Repositories
{
    public class UoW : IDisposable
    {
        private DbCmentarzContext context= new DbCmentarzContext();
        private GenericRepository<Grobowiec> grobowceRepos;
        //private GenericRepository<Course> courseRepository;

        public GenericRepository<Grobowiec> GrobowceRepos
        {
            get
            {

                if (this.grobowceRepos == null)
                {
                    this.grobowceRepos = new GenericRepository<Grobowiec>(context);
                }
                return grobowceRepos;
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
