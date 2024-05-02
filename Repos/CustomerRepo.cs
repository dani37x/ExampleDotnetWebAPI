using WebApplicationExample.Data;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly DataContext _dataContext;
        public CustomerRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _dataContext.Customer.FindAsync(id);
            return customer != null ? customer : new Customer();
        }

        public async Task<bool> AddCustomer(Customer CustomerToAdd)
        {
            _dataContext.Add(CustomerToAdd);
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCustomer(Customer customerToUpdate)
        {
            var customer = await _dataContext.Customer.FindAsync(customerToUpdate.CustomerId);

            if (customer == null)
            {
                return false;
            }

            customer.Name = customerToUpdate.Name;
            customer.Email = customerToUpdate.Email;
            customer.PhoneNumber = customerToUpdate.PhoneNumber;
            customer.Address = customerToUpdate.Address;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _dataContext.Customer.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _dataContext.Customer.Remove(customer);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
