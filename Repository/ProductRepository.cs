using System.Text.Json;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbShopContext _dbShopContext;
        public ProductRepository(DbShopContext dbShopContext)
        {
            _dbShopContext = dbShopContext;
        }

        public async Task<List<Product>> GetProducts(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int? offset)
        {
            return await _dbShopContext.Products.ToListAsync();
        }
        
    }
}
