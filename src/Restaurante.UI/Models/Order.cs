namespace Restaurante.UI.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Address Address { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
}
