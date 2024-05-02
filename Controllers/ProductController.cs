using Microsoft.AspNetCore.Mvc;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Controllers
{
    [Tags("ProductController")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            return Ok(await _repo.GetProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product productToAdd)
        {
            return Ok(await _repo.AddProduct(productToAdd));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product productToUpdate)
        {
            return Ok(await _repo.UpdateProduct(productToUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            return Ok(await _repo.DeleteProduct(id));
        }
    }
}

