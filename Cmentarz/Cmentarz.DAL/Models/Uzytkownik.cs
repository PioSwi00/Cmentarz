using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.DAL.Models
{
    [Table("Uzytkownicy")]
    [PrimaryKey(nameof(IdUzytkownik))]
    public class Uzytkownik
    {
        [Key]
        public int IdUzytkownik { get; set; }
        [Required]
        public string Login { get; set; }
        [Required,MinLength(8)]
        public string Haslo { get; set; }
     
        public virtual Wlasciciel? Wlasciciel { get; set;}
        public virtual Odwiedzajacy? Odwiedzajacy { get; set; }
        public List<Grobowiec>? Grobowce { get; set; }
    }
}
