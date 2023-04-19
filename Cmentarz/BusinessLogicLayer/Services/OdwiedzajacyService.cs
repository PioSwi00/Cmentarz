﻿using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class OdwiedzajacyService : IOdwiedzajacyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OdwiedzajacyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DodajOdwiedzajacego(Odwiedzajacy odwiedzajacy)
        {
            _unitOfWork.Odwiedzajacy.Add(odwiedzajacy);
            _unitOfWork.Save();
        }

        public void EdytujOdwiedzajacego(Odwiedzajacy odwiedzajacy)
        {
            _unitOfWork.Odwiedzajacy.Update(odwiedzajacy);
            _unitOfWork.Save();
        }

        public async Task<Odwiedzajacy> GetById(int id)
        {
            return await _unitOfWork.Odwiedzajacy.FirstOrDefaultAsync(o => o.IdOdwiedzajacy == id);
        }

        public IEnumerable<Odwiedzajacy> PobierzWszystkichOdwiedzajacych()
        {
            return (IEnumerable<Odwiedzajacy>)_unitOfWork.Odwiedzajacy.GetAll();
        }

        public IEnumerable<Odwiedzajacy> WyszukajOdwiedzajacych(int idOdwiedzajacy,string imie, string nazwisko)
        {
            var query = _unitOfWork.Odwiedzajacy.GetAll().Result.AsQueryable();

            if (idOdwiedzajacy>=0)
            {
                query = query.Where(o => o.IdOdwiedzajacy.Equals(idOdwiedzajacy));
            }

            if (!string.IsNullOrEmpty(imie))
            {
                query = query.Where(o => o.Imie.ToLower().Contains(imie.ToLower()));
            }

            if (!string.IsNullOrEmpty(nazwisko))
            {
                query = query.Where(o => o.Nazwisko.ToLower().Contains(nazwisko.ToLower()));
            }

            return query.ToList();
        }

    }

}
