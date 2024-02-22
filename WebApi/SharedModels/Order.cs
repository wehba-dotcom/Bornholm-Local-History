using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.SharedModels
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public IList<OrderLine> OrderLines { get; set; }

        public enum OrderStatus
        {
            tentative,
            cancelled,
            completed,
            shipped,
            paid
        }
    }

    public class OrderLine
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

