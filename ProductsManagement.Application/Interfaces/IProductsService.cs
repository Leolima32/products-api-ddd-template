using ProductsManagement.Application.Commands;
using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Application.Interfaces
{
    public interface IProductsService
    {
        public Task<IEnumerable<Product>> GetAllProducts();

        public Task<Product?> GetProductById(Guid id);

        public Task<bool> InsertProduct(InsertProductCommand command);

        public Task<bool> UpdateProduct(UpdateProductCommand command);

        public Task<bool> DeleteProduct(Guid id);
    }
}