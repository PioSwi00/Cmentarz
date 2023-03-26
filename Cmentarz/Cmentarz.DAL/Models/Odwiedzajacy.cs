using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Odzwiedzajacy")]
    public class Odwiedzajacy
    {
        [Key]
        [ForeignKey(nameof(Uzytkownik))]
        public int IdOdzwiedzajacy { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set;}
        public IEnumerable<Grobowiec>? Grobowce { get; set; }
    }
}
