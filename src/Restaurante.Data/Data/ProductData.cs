using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class ProductData : IProductData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public ProductData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        return _sqlDataAccess.QueryAsync<Product, Category, Product, dynamic>(
            storedProcedure: "spProducts_GetAll",
            parameters: new { },
            mapping: (product, category) =>
            {
                product.Category = category;
                return product;
            },
            splitOn: "Id");
    }

    public Task<IEnumerable<Product>> GetProduct(int? id, string? name)
    {
        return _sqlDataAccess.QueryAsync<Product, Category, Product, dynamic>(
            storedProcedure: "spProducts_GetAll",
            parameters: new { Id = id, Name = name },
            mapping: (product, category) =>
            {
                product.Category = category;
                return product;
            },
            splitOn: "Id");
    }

    public Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
    {
        return _sqlDataAccess.QueryAsync<Product, Category, Product, dynamic>(
            storedProcedure: "spProducts_GetByCategoryId",
            parameters: new { CategoryId = categoryId },
            mapping: (product, category) =>
            {
                product.Category = category;
                return product;
            },
            splitOn: "Id");
    }
}
