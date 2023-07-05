using Cmentarz.DAL.Models;

namespace Testowanie.Cmenatrz.MVC.Models
{
    public record WyszukajOdwiedzajacychRequest
    {
        public int IdOdwiedzajacy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<Odwiedzajacy> Odwiedzajacy { get; set; }
    }
}
