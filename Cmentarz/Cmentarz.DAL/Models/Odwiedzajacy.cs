using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cmentarz.DAL.Models
{
    [DataContract]
    [Table("Odzwiedzajacy")]
    [PrimaryKey(nameof(IdOdwiedzajacy))]
    public class Odwiedzajacy
    {
        [DataMember]
        [Key]
        public int IdOdwiedzajacy { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Imię odwiedzającego jest wymagane.")]
        public string Imie { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Nazwisko odwiedzającego jest wymagane.")]
        public string Nazwisko { get; set; }
        [DataMember]
        public bool czyZapalilZnicz { get; set; }
        [DataMember]
        public List<Grobowiec>? Grobowce { get; set; }

    }
}
