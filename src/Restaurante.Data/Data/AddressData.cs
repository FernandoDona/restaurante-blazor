using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class AddressData
{
    private readonly ISqlDataAccess _sqlDataAccess;
    private readonly IConfiguration _config;

    public AddressData(ISqlDataAccess sqlDataAccess, IConfiguration config)
    {
        _sqlDataAccess = sqlDataAccess;
        _config = config;
    }

    public async Task<IEnumerable<Address>> GetAddressesByUserId(int userId)
    {
        //return _sqlDataAccess.QueryAsync<Address, dynamic>("spAddresseses_GetUserById", new { Id = userId });
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("RestauranteDB")))
        {
            return await connection.QueryAsync<Address>("spAddresses_GetByUserId", new { UserId = userId }, commandType: CommandType.StoredProcedure);
        }
    }
}
