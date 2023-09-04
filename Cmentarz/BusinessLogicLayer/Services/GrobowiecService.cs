using BusinessLogicLayer.Interfaces;
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



    public List<Grobowiec> WyszukajGroby(int? idGrobu, int? idWlasciciel, string? lokalizacja, decimal? cena)
    {
        var query = _unitOfWork.Grobowce.GetAll();

        if (idGrobu.HasValue)
        {
            query = query.Where(g => g.IdGrobowiec == idGrobu.Value);
        }

        if (idWlasciciel.HasValue)
        {
            query = query.Where(g => g.IdWlasciciel == idWlasciciel.Value);
        }

        if (!string.IsNullOrEmpty(lokalizacja))
        {
            query = query.Where(g => g.Lokalizacja.Contains(lokalizacja));
        }

        if (cena.HasValue)
        {
            query = query.Where(g => g.Cena == cena.Value);
        }

        return query.ToList();
    }


    public int IloscOdwiedzajacych(int idGrobowca)
    {
        var grobowiec = _unitOfWork.Grobowce.GetById(idGrobowca);

        if (grobowiec != null)
        {
            int iloscOdwiedzajacych = grobowiec.ListaOdwiedzajacy.Count;
            if (iloscOdwiedzajacych == null)
            {
                return 0;
            }
            else { return iloscOdwiedzajacych; }
           
        }
        else
        {
            return 0;
        }
    }
    public void DodajGrobowiec(Grobowiec grobowiec)
    {
        try
        {
            if (grobowiec == null)
            {
                throw new ArgumentNullException(nameof(grobowiec), "Grobowiec nie może być null.");
            }


            _unitOfWork.Grobowce.Add(grobowiec);
            _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Tutaj możesz obsłużyć wyjątek lub przekazać go dalej
            throw ex;
        }
    }
    public IEnumerable<Grobowiec> PobierzWolneGroby()
    {
        return _unitOfWork.Grobowce.GetAll().Where(g => !g.CzyZajety);
    }

    public IEnumerable<Grobowiec> PobierzGrobyWlasciciela(int idWlasciciela)
    {
        return _unitOfWork.Grobowce.GetAll().Where(w => w.IdWlasciciel.Equals(idWlasciciela));
    }
    
}