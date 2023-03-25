using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Grobowce")]
    public class Grobowiec
    {
        [Key]
        public int IdGrobowiec { get; set; }
        [Required]
        public string IdWlasciciel { get; set; }
        [Required]
        public string Lokalizacja { get; set; }
        public decimal Cena { get; set; }
        public List<string>ListaOdwiedzajacy { get; set; }
        [Required]
        bool CzyZajety { get; set; }
    }
}
