using Dapper;
using Restaurante.Data.Data;
using Restaurante.Data.DbAccess;
using Restaurante.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Restaurant.Data.Test;
public class AddressDataTest
{
    private string connstr = "Data Source=DESKTOP-GNK2VJC;Initial Catalog=RestauranteDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //[Fact]
    public async Task GetDataAsync()
    {
        IEnumerable<Address> addresses = null;
        using (IDbConnection connection = new SqlConnection(connstr))
        {
            addresses = await connection.QueryAsync<Address>("spAddresses_GetByUserId", new { UserId = 3 }, commandType: CommandType.StoredProcedure);
        }
        Assert.Equal(1, addresses.ToList().Count);
    }

    //[Fact]
    public async Task GetDataAsync2()
    {
        IEnumerable<User> addresses = null;
        using (IDbConnection connection = new SqlConnection(connstr))
        {
            addresses = await connection.QueryAsync<User, Address, ShoppingCart, User>(
                "spUsers_GetById", 
                param: new { Id = 3 }, 
                map: (u, a, sc) =>
                {
                    u.Address = a;
                    u.ShoppingCart = sc;

                    return u;
                }, 
                splitOn: "UserId,OrderId", 
                commandType: CommandType.StoredProcedure);
        }
        Assert.Equal(1, addresses.ToList().Count);
    }

    //[Fact]
    public async Task GetDataAsync3()
    {
        var dictionary = new Dictionary<int, Order>();
        IEnumerable<Order> orders = null;
        using (IDbConnection connection = new SqlConnection(connstr))
        {
            orders = await connection.QueryAsync<Order, OrderItem, Product, Category, Address, Order>(
                "spOrders_GetByUserId",
                param: new { UserId = 4 },
                map: (order, orderItem, product, category, address) =>
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
                splitOn: "Quantity,Description,Name,Street",
                commandType: CommandType.StoredProcedure);
        }
        Assert.Equal(3, orders.ToList().Count);
    }
    [Fact]
    public async Task GetProducts()
    {
        IEnumerable<Product> products = null;
        using (IDbConnection connection = new SqlConnection(connstr))
        {
            products = await connection.QueryAsync<Product, Category, Product>(
            "spProducts_GetAll",
            param: new { },
            map: (product, category) =>
            {
                product.Category = category;
                return product;
            },
            splitOn: "Id",
            commandType: CommandType.StoredProcedure);
            
        }
    }
}