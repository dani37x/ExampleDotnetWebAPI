using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface IProductRepo
    {
        public Task<Product> GetProduct(int productId);
        public Task<bool> AddProduct(Product productModel);
        public Task<bool> UpdateProduct(Product productModel);
        public Task<bool> DeleteProduct(int productId);
    }
}
