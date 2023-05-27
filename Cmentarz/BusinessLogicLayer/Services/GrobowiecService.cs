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

    public async Task<Grobowiec> GetById(int id)
    {
        return _unitOfWork.Grobowce.FirstOrDefault(g => g.IdGrobowiec==id);
    }

    public Grobowiec GetGrobowceFilteredById(int id)
    {
        return _unitOfWork.Grobowce.GetById(id);
    }

    public IEnumerable<Grobowiec> PobierzWszystkieGrobowce()
    {
        return (IEnumerable<Grobowiec>)_unitOfWork.Grobowce.GetAll();
    }

    public void DodajZmarlegoDoGrobowca(int idGrobowca, Zmarly zmarly)
    {
        Grobowiec grobowiec = _unitOfWork.Grobowce.GetById(idGrobowca);

        if (grobowiec == null)
        {
            throw new ArgumentException("Nie znaleziono grobowca o podanym ID.");
        }

        if (grobowiec.Zmarli == null)
        {
            grobowiec.Zmarli = new List<Zmarly>();
        }

        grobowiec.Zmarli.Add(zmarly);
        _unitOfWork.Save();
    }



    public List<Grobowiec> WyszukajGroby(int idGrobu, int idWlasciciel, string lokalizacja, decimal cena)
    {
        return _unitOfWork.Grobowce
            .GetAll()
            .Where(g => g.IdGrobowiec.Equals(idGrobu) &&
                        g.IdWlasciciel.Equals(idWlasciciel) &&
                        g.Lokalizacja.Contains(lokalizacja) &&
                        g.Cena.Equals(cena))
            .ToList();
    }

    public int IloscOdwiedzajacych(int idGrobowca)
    {
        var grobowiec = _unitOfWork.Grobowce.GetById(idGrobowca);
        int ilodwiedzajacych = 0;
        foreach(var odwiedzajacy in grobowiec.ListaOdwiedzajacy)
        {
            ilodwiedzajacych++;
        }
        return ilodwiedzajacych;
    }
}