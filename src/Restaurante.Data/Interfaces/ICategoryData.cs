
namespace Restaurante.Data.Interfaces;

public interface ICategoryData
{
    Task<IEnumerable<Category>> GetAllCategories();
}