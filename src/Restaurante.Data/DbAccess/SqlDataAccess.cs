using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Restaurante.Data.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> QueryAsync<T, U>(string storedProcedure, U parameters, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))
        
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> QueryAsync<T1, T2, T, U>(string storedProcedure, U parameters, Func<T1, T2, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))
        
        return await connection.QueryAsync<T1, T2, T>(storedProcedure, param: parameters, map: mapping, splitOn: splitOn,commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))
        
        return await connection.QueryAsync<T1, T2, T3, T>(storedProcedure, param: parameters, map: mapping, splitOn: splitOn, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))
        
        return await connection.QueryAsync<T1, T2, T3, T4, T>(storedProcedure, param: parameters, map: mapping, splitOn: splitOn, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T5, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T5, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))

        return await connection.QueryAsync<T1, T2, T3, T4, T5, T>(storedProcedure, param: parameters, map: mapping, splitOn: splitOn, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T5, T6, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))

        return await connection.QueryAsync<T1, T2, T3, T4, T5, T6, T>(storedProcedure, param: parameters, map: mapping, splitOn: splitOn, commandType: CommandType.StoredProcedure);
    }

    public async Task ExecuteAsync<T>(string storedProcedure, T parameters, string connectionStringKey = "RestauranteDB")
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringKey)))
        
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
