﻿namespace Restaurante.UI.Models;

public class OrderItem
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
