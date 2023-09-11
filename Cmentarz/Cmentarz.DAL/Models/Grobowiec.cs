using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cmentarz.DAL.Models
{
    [DataContract]
    [Table("Grobowce")]
    [PrimaryKey(nameof(IdGrobowiec))]
    public class Grobowiec
    {
        [DataMember]
        [Key]
        public int IdGrobowiec { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Id właściciela nie może być puste.")]
        public int? IdWlasciciel { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Lokalizacja grobowca nie może być pusta.")]
        [MaxLength(100, ErrorMessage = "Lokalizacja grobowca może mieć maksymalnie 100 znaków.")]
        public string Lokalizacja { get; set; }
        [DataMember]
        [Range(0, 100000, ErrorMessage = "Cena grobowca nie może być mniejsza niż 0.")]
        public decimal Cena { get; set; }
        [DataMember]
        [RegularExpression("[A-H]", ErrorMessage = "Sektor musi zawierać tylko litery od A do H")]
        public String? Sektor { get; set; }
        [DataMember]
        public List<Odwiedzajacy>? ListaOdwiedzajacy { get; set; }
        [DataMember]

        public bool CzyZajety { get; set; }

        [DataMember]
        public ICollection<Zmarly>? Zmarli { get; set; }
    
    }
}
