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
public class AddressRepository : IAddressRepository
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public AddressRepository(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<Address>> GetAddressesByUserId(int userId)
    {
        return _sqlDataAccess.QueryAsync<Address, dynamic>("spAddresses_GetByUserId", new { UserId = userId });
    }

    public Task InsertAddress(Address address)
    {
        return _sqlDataAccess.ExecuteAsync<Address>("spAddress_Insert", address);
    }

    public Task UpdateAddress(Address address)
    {
        return _sqlDataAccess.ExecuteAsync<Address>("spAddress_Update", address);
    }
}
