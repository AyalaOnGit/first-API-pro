using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Servers;
using Entitys;
using Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIShop.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int offset=1)
        {
            List<Product> products = await _productService.GetProducts( name, categories,  nimPrice, maxPrice, limit,  orderBy,  offset);
            if(products!=null)
            {
                return Ok(products);
            }
            return NoContent();
        }
    }
}
