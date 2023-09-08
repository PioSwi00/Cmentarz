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
            var user = _unitOfWork.Uzytkownicy.FirstOrDefault(u => u.Login == login && u.Haslo == haslo);

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
        public IEnumerable<Uzytkownik> PobierzWszystkichUzytkownikow()
        {
            return _unitOfWork.Uzytkownicy.GetAll().ToList();
        }


        public IEnumerable<Uzytkownik> SortujUzytkownikow()
        {
            return _unitOfWork.Uzytkownicy.GetAll().OrderBy(u => u.Login);
        }

        public Grobowiec KupGrobowiec(int idUzytkownik, int idGrobowiec)
        {
            var uzytkownik = _unitOfWork.Uzytkownicy.GetById(idUzytkownik);
            var grobowiec = _unitOfWork.Grobowce.GetById(idGrobowiec);
            var wlasciciel = _unitOfWork.Wlasciciele.GetById(idUzytkownik);

            if (uzytkownik == null || grobowiec == null)
            {
                throw new Exception("Użytkownik lub grobowiec nie istnieje.");
            }

            if (grobowiec.CzyZajety == true)
            {
                throw new Exception("Grobowiec jest już zajęty.");
            }

            grobowiec.CzyZajety = true;
            grobowiec.IdWlasciciel = uzytkownik.IdUzytkownik;
            wlasciciel.IlGrobowcow++;
            _unitOfWork.Wlasciciele.Update(wlasciciel);
            _unitOfWork.Uzytkownicy.Update(uzytkownik);
            _unitOfWork.Grobowce.Update(grobowiec);
            _unitOfWork.Save();
            return grobowiec;
        }
        public void DodajUzytkownika(Uzytkownik uzytkownik)
        {
          
            var istnieje = _unitOfWork.Uzytkownicy.FirstOrDefault(u => u.Login == uzytkownik.Login);

            if (istnieje != null)
            {
                throw new Exception("Użytkownik o podanym loginie już istnieje.");
            }

            
            _unitOfWork.Uzytkownicy.Add(uzytkownik);
            _unitOfWork.Save();
        }

        public void UsunUzytkownika(int id)
        {
            var user = _unitOfWork.Uzytkownicy.GetById(id);
            if (user == null)
            {
                throw new Exception("Użytkownik o podanym identyfikatorze nie istnieje.");
            }
            _unitOfWork.Uzytkownicy.Delete(user);
            _unitOfWork.Save();
        }

        public void ZmienHaslo(int id, string noweHaslo)
        {
            var uzytkownik = _unitOfWork.Uzytkownicy.GetById(id);
            if (uzytkownik == null)
            {
                throw new Exception("Użytkownik o podanym identyfikatorze nie istnieje.");
            }
            uzytkownik.Haslo = noweHaslo;
            _unitOfWork.Save();
        }
    }
}
