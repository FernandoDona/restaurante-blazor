using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class ProductData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public ProductData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return _sqlDataAccess.QueryAsync<Product, dynamic>("spProducts_GetAll", new {});
    }

    public Task<IEnumerable<Product>> GetProducts(int? id, string? name)
    {
        return _sqlDataAccess.QueryAsync<Product, dynamic>("spProducts_GetAll", new { Id = id, Name = name });
    }
}
