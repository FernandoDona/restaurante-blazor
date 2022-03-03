using Dapper;
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

    [Fact]
    public async Task GetDataAsync3()
    {
        //var dictionary = new Dictionary<int, Order>();
        //IEnumerable<User> orders = null;
        //using (IDbConnection connection = new SqlConnection(connstr))
        //{
        //    orders = await connection.QueryAsync<Order, OrderItem, Product, Category, Address, Order>(
        //        "spOrders_GetAll",
        //        param: new { Id = 3 },
        //        map: (o, oi, p, c, a) =>
        //        {
        //            Order orderEntity;

        //            if (dictionary.TryGetValue(o.Id, out orderEntity))
        //            {
        //                dictionary.Add(o.Id, orderEntity = o);
        //            }
        //            if (orderEntity.Address == null)
        //            {
        //                if (a == null)
        //                {
        //                    a = new Address();
        //                }
        //                orderEntity.Address = a;
        //            }
        //            if (orderEntity.Items == null)
        //            {
        //                orderEntity.Items = new();
        //            }
        //            if (oi != null)
        //            {
        //                oi.Product = p;

        //                if (!orderEntity.Items.Any(i => i.OrderId == orderEntity.Id))
        //                {

        //                }
        //            }
        //        },
        //        splitOn: "UserId,OrderId",
        //        commandType: CommandType.StoredProcedure);
        //}
        //Assert.Equal(1, orders.ToList().Count);
    }
}