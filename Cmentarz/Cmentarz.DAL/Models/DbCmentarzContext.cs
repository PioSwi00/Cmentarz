using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Cmentarz.Models
{
    public class DbCmentarzContext : DbContext
    {
        public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
       

    }
 
}


