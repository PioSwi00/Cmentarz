﻿using Cmentarz.DAL.Models;

namespace Testowanie.Cmenatrz.MVC.Models
{
    public class WyszukajOdwiedzajacychViewModel
    {
        public int? IdOdwiedzajacy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Odwiedzajacy> Odwiedzajacy { get; set; }
    }
}
