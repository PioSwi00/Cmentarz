using Cmentarz.DAL.Models;

namespace Testowanie.Cmenatrz.MVC.Models
{
    public record WyszukajOdwiedzajacychResponse(int IdOdwiedzajacy, string Imie, string Nazwisko,List<Odwiedzajacy> Odwiedzajacy);
}
