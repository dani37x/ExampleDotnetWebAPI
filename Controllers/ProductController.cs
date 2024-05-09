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

        [HttpGet("{productId}")]
        public async Task<ActionResult> GetProduct(int productId)
        {
            return Ok(await _repo.GetProduct(productId));
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product productModel)
        {
            return Ok(await _repo.AddProduct(productModel));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product productModel)
        {
            return Ok(await _repo.UpdateProduct(productModel));
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            return Ok(await _repo.DeleteProduct(productId));
        }
    }
}

