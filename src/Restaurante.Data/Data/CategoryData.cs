using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.Data;
public class CategoryData : ICategoryData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public CategoryData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public Task<IEnumerable<Category>> GetAllCategories()
    {
        return _sqlDataAccess.QueryAsync<Category, dynamic>("spCategories_GetAll", new { });
    }
}
