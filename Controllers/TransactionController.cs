using Microsoft.AspNetCore.Mvc;
using WebApplicationExample.DTO;
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

        [HttpGet("{transactionId}")]
        public async Task<ActionResult> GetTransaction(int transactionId)
        {
            return Ok(await _repo.GetTransaction(transactionId));
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction(TransactionDTO transactionDTO)
        {
            return Ok(await _repo.AddTransaction(transactionDTO));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTransaction(TransactionDTO transactionDTO)
        {
            return Ok(await _repo.UpdateTransaction(transactionDTO));
        }

        [HttpDelete("{transactionId}")]
        public async Task<ActionResult> DeleteTransaction(int transactionId)
        {
            return Ok(await _repo.DeleteTransaction(transactionId));
        }
    }
}