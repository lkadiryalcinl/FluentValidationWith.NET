namespace WebAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
    }
}
