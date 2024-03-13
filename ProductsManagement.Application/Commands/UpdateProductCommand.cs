using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Application.Commands
{
    public class UpdateProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product ToEntity()
        {
            return new Product(Name,Price) with { Id = Id };
        }
    }
}