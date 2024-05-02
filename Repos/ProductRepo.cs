using WebApplicationExample.Data;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext _dataContext;
        public ProductRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> GetProduct(int id)
        {
            var product = await _dataContext.Product.FindAsync(id);
            return product != null ? product : new Product();
        }

        public async Task<bool> AddProduct(Product productToAdd)
        {
            _dataContext.Add(productToAdd);
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateProduct(Product productToUpdate)
        {
            var product = await _dataContext.Product.FindAsync(productToUpdate.ProductId);

            if (product == null)
            {
                return false;
            }

            product.Name = productToUpdate.Name;
            product.Description = productToUpdate.Description;
            product.Price = productToUpdate.Price;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _dataContext.Product.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _dataContext.Product.Remove(product);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
