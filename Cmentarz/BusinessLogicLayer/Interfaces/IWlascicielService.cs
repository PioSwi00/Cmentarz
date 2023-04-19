using Cmentarz.DAL.Models;
using System;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IWlascicielService
    {
        public IEnumerable<Wlasciciel> GetWlasciciele();
        public IEnumerable<Wlasciciel> GetByNazwisko(string nazwisko);
        public IEnumerable<Wlasciciel> WlascicielGetByOrder(string sortBy);
        //public IEnumerable<(Odwiedzajacy odwiedzajacy, IEnumerable<Zmarly> zmarli)> ListaOdwiedzajacychIGrobowca(int idGrobowca);
    }
}
