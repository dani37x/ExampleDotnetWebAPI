using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface IProductRepo
    {
        public Task<Product> GetProduct(int id);
        public Task<bool> AddProduct(Product productToAdd);
        public Task<bool> UpdateProduct(Product updateProduct);
        public Task<bool> DeleteProduct(int id);
    }
}
