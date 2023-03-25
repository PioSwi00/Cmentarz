using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Wlasciciele")]
    public class Wlasciciel
    {
        [Key]
        public int IdWlasciciel { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Adres { get; set; }
        public int IlGrobowcow { get; set; }
        [Required]
        public List<Grobowiec> Lista_Grobowcow { get; set; }
       
        public int IdUzytkownik { get; set; }
        public  Uzytkownik Uzytkownik { get; set; }
    }
}
