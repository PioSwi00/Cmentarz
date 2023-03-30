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
        private GenericRepository<Zmarly> zmarliRepos;
        private GenericRepository<Odwiedzajacy> odwiedzajacyRepos;
        private GenericRepository<Uzytkownik> uzytkownicyRepos;
        private GenericRepository<Wlasciciel> wlascicieleRepos;
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

        public GenericRepository<Zmarly> ZmarliRepos
        {
            get
            {

                if (this.zmarliRepos == null)
                {
                    this.zmarliRepos = new GenericRepository<Zmarly>(context);
                }
                return zmarliRepos;
            }
        }

        public GenericRepository<Odwiedzajacy> OdwiedzajacyRepos
        {
            get
            {

                if (this.odwiedzajacyRepos == null)
                {
                    this.odwiedzajacyRepos = new GenericRepository<Odwiedzajacy>(context);
                }
                return odwiedzajacyRepos;
            }
        }

        public GenericRepository<Uzytkownik> UzytkownicyRepos
        {
            get
            {

                if (this.uzytkownicyRepos == null)
                {
                    this.uzytkownicyRepos = new GenericRepository<Uzytkownik>(context);
                }
                return uzytkownicyRepos;
            }
        }

        public GenericRepository<Wlasciciel> WlascicieleRepos
        {
            get
            {

                if (this.wlascicieleRepos == null)
                {
                    this.wlascicieleRepos = new GenericRepository<Wlasciciel>(context);
                }
                return wlascicieleRepos;
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
