using Microsoft.EntityFrameworkCore;

namespace Assignment2_api.Models.Entities
{
    public class Product
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Artikelnummer { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }

        public CategoryModel Category { get; set; }



    }
}
