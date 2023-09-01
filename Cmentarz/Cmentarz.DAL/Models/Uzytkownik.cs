using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Required(ErrorMessage = "Login jest wymagany.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć przynajmniej 8 znaków.")]
        public string Haslo { get; set; }

        public virtual Wlasciciel? Wlasciciel { get; set;}
        public virtual Odwiedzajacy? Odwiedzajacy { get; set; }
        public List<Grobowiec>? Grobowce { get; set; }
        [BindNever]
        public string Token { get; set; } // Dodane pole Token

    }
}
