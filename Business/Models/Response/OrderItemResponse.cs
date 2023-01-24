

namespace Business.Models.Response
{
    public class OrderItemResponse
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get
            {
                return Price = Quantity;
            } 
        }
    }
}
