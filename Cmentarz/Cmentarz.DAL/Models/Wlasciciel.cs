using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cmentarz.DAL.Models
{
    [Table("Wlasciciele")]
    [PrimaryKey(nameof(IdWlasciciel))]
    public class Wlasciciel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(Uzytkownik))]
        public int IdWlasciciel { get; set; }
        [Required(ErrorMessage = "Imię właściciela jest wymagane.")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko właściciela jest wymagane.")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres właściciela jest wymagany.")]
        public string Adres { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Liczba grobowców musi być nieujemna.")]
        public int IlGrobowcow { get; set; }

        //public virtual Uzytkownik Uzytkownik { get; set; }
        public IEnumerable<Grobowiec> Grobowce { get; set; }
    }

}
