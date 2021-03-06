using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Models;
public class OrderItem
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { 
        get
        {
            if (Product is null) return 0;

            return Product.Price * Quantity;
        }
    }
}
