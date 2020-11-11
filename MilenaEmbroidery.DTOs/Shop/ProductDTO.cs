using System;

namespace MilenaEmbroidery.DTOs.Shop
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLimited { get; set; }
        public decimal CountLimited { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal Price { get; set; }
        public string PictureLink { get; set; }
    }

    public class NullProductDTO : ProductDTO
    {
        public NullProductDTO()
        {
            Name = "Empty";
            IsLimited = false;
            CountLimited = 0;
            DateAdded = DateTime.Today;
            Price = 0;
            PictureLink = "N/A";
        }
    }
}
