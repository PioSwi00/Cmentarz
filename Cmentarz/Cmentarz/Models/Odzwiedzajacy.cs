using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Cmentarz")]
    public class Odzwiedzajacy
    {
        [Key]
        public int IdOdzwiedzajacy { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
    }
}
