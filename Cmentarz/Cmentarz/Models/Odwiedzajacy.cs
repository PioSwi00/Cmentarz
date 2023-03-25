using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Odzwiedzajacy")]
    public class Odwiedzajacy
    {
        [Key]
        public int IdOdzwiedzajacy { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        //public ICollection<Odzwiedzajacy> OdzwiedzajacyList { get; set; }
        public List<Grobowiec> Grobowce { get; set; }
        public List<OdwiedzajacyGrobowce> Odwiedzajacy_Grobowce { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}
