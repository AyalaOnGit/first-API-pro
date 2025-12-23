namespace Services;

using Entities;
using Repository;


public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
   
    public async Task<List<Product>> GetProducts(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int? offset)
    {
        return await _productRepository.GetProducts( name, categories,  nimPrice, maxPrice,  limit,  orderBy, offset);
    }

}
