namespace Order_Management_API.Models
{
    public class Order
    {
        public Order(string orderName, Guid userId)
        {
            OrderName = orderName;
            UserId = userId;
        }


        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public Guid UserId { get; set; }

    }
}
