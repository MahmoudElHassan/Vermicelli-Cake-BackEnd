using E_Commerce_DAL.OrderAggregate;

namespace E_Commerce_DAL;

public class Order : BaseEntity
{
    public Order()
    {
    }
    public Order(IList<OrderItem> orderItems, string buyerEmail,
        Address shipToAddress, DeliveryMethod deliveryMethod, decimal subtotal, string paymentIntentId)
    {
        BuyerEmail = buyerEmail;
        ShipToAddress = shipToAddress;
        DeliveryMethod = deliveryMethod;
        OrderItems = orderItems;
        Subtotal = subtotal;
        PaymentIntentId = paymentIntentId;
    }

    public string BuyerEmail { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public Address ShipToAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
    public IList<OrderItem> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
    //public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string PaymentIntentId { get; set; }

    public decimal GetTotal()
    {
        return Subtotal + DeliveryMethod.Price;
    }
}