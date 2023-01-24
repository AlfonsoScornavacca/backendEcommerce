

namespace Business.Models.Request
{
    public class CreateOrder
    {
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<CreateOrderItem> Items { get; set; }
    }
}
