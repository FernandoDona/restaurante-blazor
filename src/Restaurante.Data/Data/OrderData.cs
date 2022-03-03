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
        return _sqlDataAccess.QueryAsync<Order, dynamic>("spOrders_GetAll", new { });
    }

    public Task<IEnumerable<Order>> GetOrderByUserId(int userId)
    {
        return _sqlDataAccess.QueryAsync<Order, dynamic>("spOrders_GetAll", new { UserId = userId });
    }
}
