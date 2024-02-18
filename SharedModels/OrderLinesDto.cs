
namespace Shared.Models
{
    public class OrderLinesDto
    {
        public class OrderLine
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
