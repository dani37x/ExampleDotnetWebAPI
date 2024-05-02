using Microsoft.AspNetCore.Mvc;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Controllers
{

    [Tags("TransactionController")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo _repo;

        public TransactionController(ITransactionRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            return Ok(await _repo.GetTransaction(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transaction transactionToAdd)
        {
            return Ok(await _repo.AddTransaction(transactionToAdd));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTransaction(Transaction transactionToUpdate)
        {
            return Ok(await _repo.UpdateTransaction(transactionToUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            return Ok(await _repo.DeleteTransaction(id));
        }
    }
}