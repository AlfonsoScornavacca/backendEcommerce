
namespace DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
