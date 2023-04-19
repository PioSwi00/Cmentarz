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
    public class ZmarlyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ZmarlyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Zmarly> PobierzZmarlychZPrzedzialuCzasu(DateTime dataOd, DateTime dataDo)
        {
            return _unitOfWork.Zmarli.GetAll().Where(z => z.DataSmierci >= dataOd && z.DataSmierci <= dataDo);
        }
        public IEnumerable<Zmarly> PobierzZmarlychPosortowanychWedlugWieku()
        {
            return _unitOfWork.Zmarli.GetAll().OrderBy(z => DateTime.Now.Year - z.DataUrodzenia.Year);
        }
    }
}