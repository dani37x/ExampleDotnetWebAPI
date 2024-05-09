using WebApplicationExample.DTO;
using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface ITransactionRepo
    {
        public Task<Transaction> GetTransaction(int transactionId);
        public Task<bool> AddTransaction(TransactionDTO transactionDTO);
        public Task<bool> UpdateTransaction(TransactionDTO transactionDTO);
        public Task<bool> DeleteTransaction(int transactionId);
    }
}
