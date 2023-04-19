﻿using BusinessLogicLayer.Interfaces;
using Cmentarz.DAL.Models;
using Cmentarz.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GrobowiecService : IGrobowiecService
{
    private readonly IUnitOfWork _unitOfWork;

    public GrobowiecService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void DodajGrobowiec(Grobowiec grobowiec)
    {
        _unitOfWork.Grobowce.Add(grobowiec);
        _unitOfWork.Save();
    }

    public void EdytujGrobowiec(Grobowiec grobowiec)
    {
        _unitOfWork.Grobowce.Update(grobowiec);
        _unitOfWork.Save();
    }

    public async Task<Grobowiec> GetById(int id)
    {
        return await _unitOfWork.Grobowce.FirstOrDefaultAsync(g => g.IdGrobowiec==id);
    }

    public Grobowiec GetGrobowceFilteredById(int id)
    {
        return _unitOfWork.Grobowce.GetById(id).Result;
    }

    public IEnumerable<Grobowiec> PobierzWszystkieGrobowce()
    {
        return (IEnumerable<Grobowiec>)_unitOfWork.Grobowce.GetAll();
    }

    public void DodajZmarlegoDoGrobowca(int idGrobowca, Zmarly zmarly)
    {
        Grobowiec grobowiec = _unitOfWork.Grobowce.GetById(idGrobowca).Result;

        if (grobowiec == null)
        {
            throw new ArgumentException("Nie znaleziono grobowca o podanym ID.");
        }
        
        grobowiec.Zmarli.Append(zmarly);
        _unitOfWork.Save();
    }
}