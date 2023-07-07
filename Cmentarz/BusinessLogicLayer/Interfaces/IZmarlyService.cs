using Cmentarz.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IZmarlyService
    {
        public IEnumerable<Zmarly> PobierzZmarlychZPrzedzialuCzasu(DateTime dataOd, DateTime dataDo);
        public IEnumerable<Zmarly> PobierzZmarlychPosortowanychWedlugWieku();
        public IEnumerable<Zmarly> PobierzWszystkichZmarlych();
    }
}
