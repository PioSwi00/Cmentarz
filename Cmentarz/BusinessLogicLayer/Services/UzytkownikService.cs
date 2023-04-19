using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UzytkownikService : IUzytkownikService
    {
        private readonly IUnitOfWork _unitOfWork;



        public UzytkownikService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Uzytkownik Login(string login, string haslo)
        {
            var user = _unitOfWork.Uzytkownicy.FirstOrDefault(u => u.Login == login);

            if (user == null)
            {
                return null;
            }

            if (user.Haslo != haslo)
            {
                return null;
            }

            return user;



        }
        public IEnumerable<Uzytkownik> SortujUzytkownikow()
        {
            return _unitOfWork.Uzytkownicy.GetAll().OrderBy(u => u.Login);
        }

        public void KupGrobowiec(int idUzytkownik, int idGrobowiec)
        {
            var uzytkownik = _unitOfWork.Uzytkownicy.GetById(idUzytkownik);
            var grobowiec = _unitOfWork.Grobowce.GetById(idGrobowiec);

            if (uzytkownik == null || grobowiec == null)
            {
                throw new Exception("Użytkownik lub grobowiec nie istnieje.");
            }

            if (grobowiec.CzyZajety == true)
            {
                throw new Exception("Grobowiec jest już zajęty.");
            }

            grobowiec.CzyZajety = true;

            _unitOfWork.Uzytkownicy.Update(uzytkownik);
            _unitOfWork.Grobowce.Update(grobowiec);
            _unitOfWork.Save();
        }

    }
}
