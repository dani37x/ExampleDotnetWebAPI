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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id)
        {
            return Ok(await _repo.GetCustomer(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer CustomerToAdd)
        {
            return Ok(await _repo.AddCustomer(CustomerToAdd));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer CustomerToUpdate)
        {
            return Ok(await _repo.UpdateCustomer(CustomerToUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            return Ok(await _repo.DeleteCustomer(id));
        }
    }
}
