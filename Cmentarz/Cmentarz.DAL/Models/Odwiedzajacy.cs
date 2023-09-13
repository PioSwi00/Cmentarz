using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Cmentarz.DAL.Models
{
    
    [Table("Odzwiedzajacy")]
    [PrimaryKey(nameof(IdOdwiedzajacy))]
    public class Odwiedzajacy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(Uzytkownik))]
        public int IdOdwiedzajacy { get; set; }
        
        [Required(ErrorMessage = "Imię odwiedzającego jest wymagane.")]
        public string Imie { get; set; }
        
        [Required(ErrorMessage = "Nazwisko odwiedzającego jest wymagane.")]
        public string Nazwisko { get; set; }
      
        public bool czyZapalilZnicz { get; set; }
        [JsonIgnore]
        public List<Grobowiec>? Grobowce { get; set; }

    }
}
 