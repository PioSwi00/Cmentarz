using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Uzytkownicy")]
    public class Uzytkownik
    {
        [Key]
        public int IdUzytkownik { get; set; }
        [Required]
        public string Login { get; set; }
        [Required,MinLength(8)]
        public string Haslo { get; set; }
    }
}
