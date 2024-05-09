using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<Customer> GetCustomer(int CustomerId);
        public Task<bool> AddCustomer(Customer customerModel);
        public Task<bool> UpdateCustomer(Customer customerModel);
        public Task<bool> DeleteCustomer(int CustomerId);
    }
}
