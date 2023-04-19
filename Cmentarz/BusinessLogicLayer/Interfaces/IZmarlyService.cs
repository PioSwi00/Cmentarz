using Cmentarz.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    internal interface IZmarlyRepository
    {
        public IEnumerable<Zmarly> PobierzZmarlychZPrzedzialuCzasu(DateTime dataOd, DateTime dataDo);
        public IEnumerable<Zmarly> PobierzZmarlychPosortowanychWedlugWieku();
    }
}
