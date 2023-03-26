using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Grobowce")]
    [PrimaryKey(nameof(IdGrobowiec))]
    public class Grobowiec
    {
        [Key]
        public int IdGrobowiec { get; set; }
        [ForeignKey(nameof(Wlasciciel))]
        public int IdWlasciciel { get; set; }
        [Required]
        public string? Lokalizacja { get; set; }
        public decimal Cena { get; set; }
        public IEnumerable<Odwiedzajacy>?ListaOdwiedzajacych { get; set; }
        [Required]
        bool CzyZajety { get; set; }
        public IEnumerable<Zmarly>? Zmarli { get; set; }

    }
}
