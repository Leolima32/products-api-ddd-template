using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Entities;
using ProductsManagement.Domain.Interfaces;

namespace ProductsManagement.Infra.Repositories
{
    public class ProductsRepository(AppDbContext context): IProductsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Product>> GetAll() {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(Guid id) {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Product product) {
            _context.Products.Add(product);

            return await _context.SaveChangesAsync(CancellationToken.None) > 0;
        }

        public async Task<bool> Update(Product model) {
            var currentProduct = await _context.Products.Where(x => x.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();

            if(currentProduct == null) {
                return false;
            }

            currentProduct = currentProduct with {
                Name = model.Name,
                Price = model.Price
            };

            _context.Update(currentProduct);
            return await _context.SaveChangesAsync(CancellationToken.None) > 0;
        }

        public async Task<bool> Delete(Guid id) {
            var currentProduct = await GetById(id);
            
            if(currentProduct == null) {
                return false;
            }

            _context.Products.Remove(currentProduct);
            return await _context.SaveChangesAsync(CancellationToken.None) > 0;
        }
    }
}