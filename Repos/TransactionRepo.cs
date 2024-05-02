using Azure.Core;
using Microsoft.Extensions.Hosting;
using WebApplicationExample.Data;
using WebApplicationExample.Interfaces;
using WebApplicationExample.Models;

namespace WebApplicationExample.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly DataContext _dataContext;
        public TransactionRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Transaction> GetTransaction(int id)
        {
            var transaction = await _dataContext.Transaction.FindAsync(id);
            return transaction != null ? transaction : new Transaction();
        }

        public async Task<bool> AddTransaction(Transaction transactionToAdd)
        {
            var customer = await _dataContext.Customer.FindAsync(transactionToAdd.CustomerId);
            var product = await _dataContext.Product.FindAsync(transactionToAdd.ProductId);

            if (customer == null || product == null)
            {
                return false;
            }

            var postToAdd = new Transaction
            {
                Quantity = transactionToAdd.Quantity,
                TransactionDate = transactionToAdd.TransactionDate,
                Customer = customer,
                Product = product
            };

            await _dataContext.Transaction.AddAsync(postToAdd);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateTransaction(Transaction transactionToUpdate)
        {
            var transaction = await _dataContext.Transaction.FindAsync(transactionToUpdate.TransactionId);
            var customer = await _dataContext.Customer.FindAsync(transactionToUpdate.TransactionId);
            var product = await _dataContext.Product.FindAsync(transactionToUpdate.TransactionId);

            if (transaction == null || customer ==  null || product == null)
            {
                return false;
            }
            transaction.Quantity = transactionToUpdate.Quantity;
            transaction.TransactionDate = transactionToUpdate.TransactionDate;
            transaction.CustomerId = transactionToUpdate.CustomerId;
            transaction.ProductId = transactionToUpdate.ProductId;
            transaction.Customer = customer;
            transaction.Product = product;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            var transaction = await _dataContext.Transaction.FindAsync(id);

            if (transaction == null)
            {
                return false;
            }

            _dataContext.Transaction.Remove(transaction);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}

