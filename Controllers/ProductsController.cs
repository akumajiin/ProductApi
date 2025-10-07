using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// GET /api/products - Returns a JSON array of all products
        /// </summary>
        /// <returns>List of all products from the database</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                _logger.LogInformation("Retrieving all products from database");
                var products = await _productService.GetAllProductsAsync();
                _logger.LogInformation("Successfully retrieved {Count} products", products.Count());
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products");
                return StatusCode(500, "An error occurred while retrieving products");
            }
        }/// <summary>
        /// GET /api/products/{id} - Returns a JSON object of the product with the
        [NonAction]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving product with ID {Id} from database", id);
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product with ID {Id} not found", id);
                    return NotFound();
                }
                _logger.LogInformation("Successfully retrieved product with ID {Id}", id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving product with ID {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the product");
            }
        }
        
    }
}