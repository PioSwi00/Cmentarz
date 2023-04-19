using BusinessLogicLayer.Interfaces;
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

        public async Task<bool> VerifyUser(string username, string password)
        {
            var user = await _unitOfWork.Uzytkownicy.FirstOrDefaultAsync(u => u.Login == username);
            if (user == null)
            {
                return false;
            }

            return user.Haslo == password;
        }
    }
}
