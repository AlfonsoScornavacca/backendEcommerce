

namespace Business.Models.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderItemResponse> Items { get; set; }
        public decimal Total
        {
            get {
                return Items.Sum(x => x.Total);
                
                }
                
        }

    }
}
