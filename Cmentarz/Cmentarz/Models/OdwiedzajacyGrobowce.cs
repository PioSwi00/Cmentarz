﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cmentarz.Models
{
    [Table("OdwiedzajacyGrobowce")]
    public class OdwiedzajacyGrobowce
    {
        [Key]
        public int Id { get; set; }


        public int IdOdwiedzajacy { get; set; }

        public int IdGrobowiec { get; set; }

       
        public Odzwiedzajacy Odwiedzajacy { get; set; }

        
        public Grobowiec Grobowiec { get; set; }
    }
}