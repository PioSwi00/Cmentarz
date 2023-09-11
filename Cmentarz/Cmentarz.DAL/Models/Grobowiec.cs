using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cmentarz.DAL.Models
{
   
    [Table("Grobowce")]
    [PrimaryKey(nameof(IdGrobowiec))]
    public class Grobowiec
    {
       
        [Key]
        public int IdGrobowiec { get; set; }
    
        [Required(ErrorMessage = "Id właściciela nie może być puste.")]
        public int? IdWlasciciel { get; set; }
     
        [Required(ErrorMessage = "Lokalizacja grobowca nie może być pusta.")]
        [MaxLength(100, ErrorMessage = "Lokalizacja grobowca może mieć maksymalnie 100 znaków.")]
        public string Lokalizacja { get; set; }
       
        [Range(0, 100000, ErrorMessage = "Cena grobowca nie może być mniejsza niż 0.")]
        public decimal Cena { get; set; }
        
        [RegularExpression("[A-H]", ErrorMessage = "Sektor musi zawierać tylko litery od A do H")]
        public String? Sektor { get; set; }
      
        public List<Odwiedzajacy>? ListaOdwiedzajacy { get; set; }
        

        public bool CzyZajety { get; set; }

        
        public ICollection<Zmarly>? Zmarli { get; set; }
    
    }
}
