using Entitys;
using Repository;

namespace Servers
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int? offset);
       
    }
}