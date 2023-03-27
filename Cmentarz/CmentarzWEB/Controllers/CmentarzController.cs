using Cmentarz.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cmentarz.WEB.Controllers
{
    public class CmentarzController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        CmentarzController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }   
    }
}
