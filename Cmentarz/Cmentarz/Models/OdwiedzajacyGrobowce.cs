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

        [ForeignKey("IdOdwiedzajacy")]
        public Odwiedzajacy? Odwiedzajacy { get; set; }

        [ForeignKey("IdGrobowiec")]
        public Grobowiec? Grobowiec { get; set; }
    }
}