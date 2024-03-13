using ProductsManagement.Application.Commands;
using ProductsManagement.Application.Interfaces;
using ProductsManagement.Domain.Entities;
using ProductsManagement.Domain.Interfaces;

namespace ProductsManagement.Application.Services
{
    public class ProductsService(IProductsRepository repository): IProductsService
    {
        private readonly IProductsRepository _repository = repository;

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> InsertProduct(InsertProductCommand command)
        {
            return await _repository.Insert(command.ToEntity());
        }

        public async Task<bool> UpdateProduct(UpdateProductCommand command)
        {
            return await _repository.Update(command.ToEntity());
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}