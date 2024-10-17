﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_hdeleon.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerId { get; set; }

        public string? Name { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Alcohol { get; set; }
    
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }
    }
}