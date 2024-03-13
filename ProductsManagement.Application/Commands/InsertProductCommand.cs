using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Application.Commands
{
    public class InsertProductCommand
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product ToEntity() {
            return new Product(Name, Price);
        }
    }
}