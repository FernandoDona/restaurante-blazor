using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class OrderData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public OrderData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<Order>> GetAllOrders()
    {
        var dictionary = new Dictionary<int, Order>();

        return _sqlDataAccess.QueryAsync<Order, OrderItem, Product, Category, Address, Order, dynamic>(
            storedProcedure: "spOrders_GetAll", 
            parameters: new { },
            mapping: (order, orderItem, product, category, address) =>
            {
                Order orderEntry;

                if (!dictionary.TryGetValue(order.Id, out orderEntry))
                {
                    orderEntry = order;
                    orderEntry.Items = new();
                    dictionary.Add(orderEntry.Id, orderEntry = order);
                }

                orderEntry.Address = address;

                if (orderItem is not null)
                {
                    orderItem.Product = product;
                    orderItem.Product.Category = category;

                    if (!orderEntry.Items.Any(i => i.ProductId == orderItem.ProductId))
                    {
                        orderEntry.Items.Add(orderItem);
                    }
                }

                return orderEntry;
            },
            splitOn: "Quantity,Description,Name,Street");
    }

    public Task<IEnumerable<Order>> GetOrderByUserId(int userId)
    {
        var dictionary = new Dictionary<int, Order>();

        return _sqlDataAccess.QueryAsync<Order, OrderItem, Product, Category, Address, Order, dynamic>(
            storedProcedure: "spOrders_GetByUserId",
            parameters: new { UserId = userId },
            mapping: (order, orderItem, product, category, address) =>
            {
                Order orderEntry;

                if (!dictionary.TryGetValue(order.Id, out orderEntry))
                {
                    orderEntry = order;
                    orderEntry.Items = new();
                    dictionary.Add(orderEntry.Id, orderEntry = order);
                }

                orderEntry.Address = address;

                if (orderItem is not null)
                {
                    orderItem.Product = product;
                    orderItem.Product.Category = category;

                    if (!orderEntry.Items.Any(i => i.ProductId == orderItem.ProductId))
                    {
                        orderEntry.Items.Add(orderItem);
                    }
                }

                return orderEntry;
            },
            splitOn: "Quantity,Description,Name,Street");
    }
}
