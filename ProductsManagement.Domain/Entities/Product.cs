using ProductsManagement.Domain.Entities.Base;

namespace ProductsManagement.Domain.Entities
{
    public record Product(string Name, decimal Price) : BaseEntity;
}