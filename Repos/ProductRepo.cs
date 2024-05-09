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
        public async Task<Product> GetProduct(int productId)
        {
            var product = await _dataContext.Product.FindAsync(productId);
            return product != null ? product : new Product();
        }

        public async Task<bool> AddProduct(Product productModel)
        {
            _dataContext.Add(productModel);
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateProduct(Product productModel)
        {
            var product = await _dataContext.Product.FindAsync(productModel.ProductId);

            if (product == null)
            {
                return false;
            }

            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Price = productModel.Price;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            var product = await _dataContext.Product.FindAsync(ProductId);

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
