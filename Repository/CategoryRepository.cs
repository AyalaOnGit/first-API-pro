using System.Text.Json;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbShopContext _dbShopContext;
        public CategoryRepository(DbShopContext dbShopContext)
        {
            _dbShopContext = dbShopContext;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _dbShopContext.Categories.ToListAsync();
        }

    
    }
}
