﻿namespace backend_hdeleon.Models.DTOs.Beer
{
    public class BeerDto
    {
        public int BeerId { get; set; }

        public string? Name { get; set; }

        public int BrandId { get; set; }

        public decimal Alcohol { get; set; }
    }
}