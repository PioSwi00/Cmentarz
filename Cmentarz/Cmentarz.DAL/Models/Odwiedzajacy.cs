using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Odzwiedzajacy")]
    [PrimaryKey(nameof(IdOdwiedzajacy))]
    public class Odwiedzajacy
    {
        [Key]
        public int IdOdwiedzajacy { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public List<Grobowiec>? Grobowce { get; set; }

    }
}
