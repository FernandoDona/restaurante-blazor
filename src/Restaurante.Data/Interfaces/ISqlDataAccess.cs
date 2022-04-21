
namespace Restaurante.Data.Interfaces;

public interface ISqlDataAccess
{
    Task ExecuteAsync<T>(string procedure, T parameters, string connectionStringKey = "RestauranteDB");
    Task<T> QuerySingleAsync<T, U>(string storedProcedure, U parameters, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T, U>(string procedure, U parameters, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T1, T2, T, U>(string storedProcedure, U parameters, Func<T1, T2, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T5, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T5, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB");
    Task<IEnumerable<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T, U>(string storedProcedure, U parameters, Func<T1, T2, T3, T4, T5, T6, T> mapping, string splitOn, string connectionStringKey = "RestauranteDB");
}