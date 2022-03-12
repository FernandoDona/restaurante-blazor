
namespace Restaurante.Data.Interfaces;

public interface IProductData
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<IEnumerable<Product>> GetProduct(int? id, string? name);
    Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
}