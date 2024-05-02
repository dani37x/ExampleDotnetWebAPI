using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<Customer> GetCustomer(int id);
        public Task<bool> AddCustomer(Customer customerToAdd);
        public Task<bool> UpdateCustomer(Customer updateCustomer);
        public Task<bool> DeleteCustomer(int id);
    }
}
