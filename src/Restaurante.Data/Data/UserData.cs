using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class UserData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public UserData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<User>> GetUserById(int id)
    {
        return _sqlDataAccess.QueryAsync<User, Address, ShoppingCart, User, dynamic>(
            "spUsers_GetById", 
            new { Id = id }, 
            mapping: (u, a, sc) =>
            {
                u.Address = a;
                u.ShoppingCart = sc;

                return u;
            },
            splitOn: "UserId,OrderId");
    }
}
