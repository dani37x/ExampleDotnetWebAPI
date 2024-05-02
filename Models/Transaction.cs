using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExample.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
