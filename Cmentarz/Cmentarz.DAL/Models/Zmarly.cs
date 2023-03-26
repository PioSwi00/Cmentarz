﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("Zmarli")]
    public class Zmarly
    {
        [Key]
        public int IdZmarly { get; set; }
        [Required]
        public string Imie { get; set;}
        [Required]
        public string Nazwisko { get; set;}
        [Required]
        public DateTime DataUrodzenia { get; set; }
        [Required]
        public DateTime DataSmierci { get; set; }
       
    }
}
