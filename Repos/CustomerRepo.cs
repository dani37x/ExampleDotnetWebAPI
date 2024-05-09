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

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _dataContext.Customer.FindAsync(customerId);
            return customer != null ? customer : new Customer();
        }

        public async Task<bool> AddCustomer(Customer customerModel)
        {
            _dataContext.Add(customerModel);
            return await _dataContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateCustomer(Customer customerModel)
        {
            var customer = await _dataContext.Customer.FindAsync(customerModel.CustomerId);

            if (customer == null)
            {
                return false;
            }

            customer.Name = customerModel.Name;
            customer.Email = customerModel.Email;
            customer.PhoneNumber = customerModel.PhoneNumber;
            customer.Address = customerModel.Address;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var customer = await _dataContext.Customer.FindAsync(customerId);

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
