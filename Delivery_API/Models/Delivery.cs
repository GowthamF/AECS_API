namespace Delivery_API.Models
{
    public class Delivery
    {

        public Delivery(int id, string trackingCode, int orderId)
        {
            Id = id;
            TrackingCode = trackingCode;
            OrderId = orderId;
        }

        public int Id { get; set; }
        public string TrackingCode { get; set; }
        public  string? Status { get; set; }
        public int OrderId { get; set; }
    }
}
