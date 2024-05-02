using WebApplicationExample.Models;

namespace WebApplicationExample.Interfaces
{
    public interface ITransactionRepo
    {
        public Task<Transaction> GetTransaction(int id);
        public Task<bool> AddTransaction(Transaction transactionToAdd);
        public Task<bool> UpdateTransaction(Transaction updateTransaction);
        public Task<bool> DeleteTransaction(int id);
    }
}
