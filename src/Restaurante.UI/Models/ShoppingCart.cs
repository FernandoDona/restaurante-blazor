namespace Restaurante.UI.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public Order? Order { get; set; }
}