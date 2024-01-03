using Microsoft.AspNetCore.Mvc;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.Abstaction;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace Vending_Machine___Rest_API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productsService)
        {
            this.productService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var product = await productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct([FromRoute] int id, [FromBody] CreateOrUpdateProductRequest request)
        {
            var product = await productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            await productService.UpdateProduct(id, request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateOrUpdateProductRequest request)
        {
            var product = await productService.CreateProduct(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await productService.DeleteProduct(id);

            return Ok();
        }
    }
}