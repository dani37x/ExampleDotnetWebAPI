using Azure.Core;
using Microsoft.Extensions.Hosting;
using WebApplicationExample.Data;
using WebApplicationExample.DTO;
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
        public async Task<Transaction> GetTransaction(int transactionId)
        {
            var transaction = await _dataContext.Transaction.FindAsync(transactionId);
            return transaction != null ? transaction : new Transaction();
        }

        public async Task<bool> AddTransaction(TransactionDTO transactionDTO)
        {
            var customer = await _dataContext.Customer.FindAsync(transactionDTO.CustomerId);
            var product = await _dataContext.Product.FindAsync(transactionDTO.ProductId);

            if (customer == null || product == null)
            {
                return false;
            }

            var transaction = new Transaction
            {
                Quantity = transactionDTO.Quantity,
                TransactionDate = transactionDTO.TransactionDate,
                Customer = customer,
                Product = product
            };

            await _dataContext.Transaction.AddAsync(transaction);
            await _dataContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateTransaction(TransactionDTO transactionDTO)
        {
            var transaction = await _dataContext.Transaction.FindAsync(transactionDTO.TransactionId);
            var customer = await _dataContext.Customer.FindAsync(transactionDTO.CustomerId);
            var product = await _dataContext.Product.FindAsync(transactionDTO.ProductId);

            if (transaction == null || customer ==  null || product == null)
            {
                return false;
            }
            transaction.Quantity = transactionDTO.Quantity;
            transaction.TransactionDate = transactionDTO.TransactionDate;
            transaction.CustomerId = transactionDTO.CustomerId;
            transaction.ProductId = transactionDTO.ProductId;
            transaction.Customer = customer;
            transaction.Product = product;
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTransaction(int transactionId)
        {
            var transaction = await _dataContext.Transaction.FindAsync(transactionId);

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

