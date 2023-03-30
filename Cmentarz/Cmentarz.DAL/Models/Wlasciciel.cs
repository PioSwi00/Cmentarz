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
        [ForeignKey(nameof(Uzytkownik))]
        public int IdWlasciciel { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        [Required]
        public string Adres { get; set; }
        public int IlGrobowcow { get; set; }
          
        public virtual Uzytkownik Uzytkownik { get; set; }
        public IEnumerable<Grobowiec> Grobowce { get; set; }
        
    }
}
