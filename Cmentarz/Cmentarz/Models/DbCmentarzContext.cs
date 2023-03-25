using Cmentarz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Cmentarz.Models
{
    public class DbCmentarzContext :DbContext
    {

        public DbCmentarzContext(DbContextOptions<DbCmentarzContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OdwiedzajacyGrobowce>()
                   .HasOne(o => o.Grobowiec)
                   .WithMany(op => op.Odwiedzajacy_Grobowce)
                   .HasForeignKey(odi => odi.IdGrobowiec);

            modelBuilder.Entity<OdwiedzajacyGrobowce>()
                   .HasOne(o => o.Odwiedzajacy)
                   .WithMany(op => op.Odwiedzajacy_Grobowce)
                   .HasForeignKey(odi => odi.IdOdwiedzajacy);


        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Odzwiedzajacy> Odwiedzajacy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Zmarly> Zmarli { get; set; }
        public DbSet<Grobowiec> Grobowce { get; set; }
        public DbSet<OdwiedzajacyGrobowce> Odwiedzajacy_Grobowce{get;set;}

    }
 
}


