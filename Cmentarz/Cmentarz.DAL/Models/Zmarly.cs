using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cmentarz.DAL.Models
{
    [Table("Zmarli")]
    [PrimaryKey(nameof(IdZmarly))]
    public class Zmarly
    {
        [Key]
        public int IdZmarly { get; set; }
      
        [Required(ErrorMessage = "Imię zmarłego jest wymagane.")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko zmarłego jest wymagane.")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Data urodzenia zmarłego jest wymagana.")]
        public DateTime DataUrodzenia { get; set; }

        [Required(ErrorMessage = "Data śmierci zmarłego jest wymagana.")]
        public DateTime DataSmierci { get; set; }

        [ForeignKey(nameof(Grobowiec))]
        public int GrobowiecID { get; set; }
        public Grobowiec Grobowiec { get; set; }
    }
}
