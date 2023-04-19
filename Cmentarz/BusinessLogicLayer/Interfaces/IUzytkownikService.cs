using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUzytkownikService
    {
        Task<bool> VerifyUser(string username, string password);
    }
}
