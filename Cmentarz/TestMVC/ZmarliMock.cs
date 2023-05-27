using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;

namespace TestMVC
{
    public class ZmarliMock : IZmarlyService
    {
        public IEnumerable<Zmarly> PobierzZmarlychPosortowanychWedlugWieku()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zmarly> PobierzZmarlychZPrzedzialuCzasu(DateTime dataOd, DateTime dataDo)
        {
            throw new NotImplementedException();
        }
    }
}