using ProductsManagement.Domain.Entities;

namespace ProductsManagement.Domain.Interfaces
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetAll();

        public Task<Product?> GetById(Guid id);

        public Task<bool> Insert(Product product);

        public Task<bool> Update(Product model);

        public Task<bool> Delete(Guid id);
    }
}