using Cmentarz.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUzytkownikService
    {
        public Uzytkownik Login(string login, string haslo);

    }
}
