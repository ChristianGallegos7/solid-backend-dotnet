namespace backend_hdeleon.Models.DTOs
{
    public class BeerUpdateDto
    {
        public int BeerId { get; set; }

        public string Name { get; set; }

        public int BrandId { get; set; }

        public decimal Alcohol { get; set; }
    }
}
