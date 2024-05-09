using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationExample.Models;

namespace WebApplicationExample.DTO
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int Quantity { get; set; } = 1;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; } = 2;
        public int ProductId { get; set; } = 1;
    }
}
