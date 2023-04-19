﻿using Cmentarz.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGrobowiecService
    {
        void DodajGrobowiec(Grobowiec grobowiec);
        void EdytujGrobowiec(Grobowiec grobowiec);
    
        IEnumerable<Grobowiec> PobierzWszystkieGrobowce();
        public List<Grobowiec> GetGrobowceFilteredById(int id);
    }
}