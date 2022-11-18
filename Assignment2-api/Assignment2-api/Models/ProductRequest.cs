using Assignment2_api.Models.Entities;

namespace Assignment2_api.Models
{
    public class ProductRequest
    {
        public string Artikelnummer { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }

        public CategoryModel Category { get; set; }
    }
}
