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

    }
}
