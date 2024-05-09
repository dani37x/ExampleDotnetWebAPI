using Microsoft.AspNetCore.Mvc;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Controllers
{
    [Tags("CustomerController")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repo;

        public CustomerController(ICustomerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetCustomer(int customerId)
        {
            return Ok(await _repo.GetCustomer(customerId));
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customerModel)
        {
            return Ok(await _repo.AddCustomer(customerModel));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customerModel)
        {
            return Ok(await _repo.UpdateCustomer(customerModel));
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            return Ok(await _repo.DeleteCustomer(customerId));
        }
    }
}
