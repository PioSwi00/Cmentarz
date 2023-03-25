using Cmentarz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Cmentarz.Models
{
    public class DbCmentarzContext:DbContext
    {
    
        public DbCmentarzContext():base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cmentarz;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"){ }
        

       public DbSet<Uzytkownik> Uzytkownicy { get; set; }
       public DbSet<Odzwiedzajacy> Odwiedzajacy { get; set; }
       public DbSet<Wlasciciel> Wlasciciele { get; set; }

    }
 
}


