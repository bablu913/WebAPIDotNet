using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var products = await _productRepository.GetProducts();
            if (products == null || products.Count == 0) { return NotFound(); }
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product? pdtFound = await _productRepository.GetProductById(id);
            if (pdtFound == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(pdtFound);
            }
        }
        [HttpPut("{price}")]
        public async Task<ActionResult<Product>> UpdateProductPrice(int id,double newPrice)
        {
            Product? product = null;
            product = await _productRepository.UpdateProductPrice(id,newPrice);
            if (product != null)
            {
                return NoContent();
            }
            else {
                return NotFound("Id not found");
            }
           
        }
        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<bool>> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }
            else
            {
                bool value = await _productRepository.CreateProduct(product);
                return Ok(value);
            }
        }
        [HttpDelete]

        public async Task<ActionResult> DeleteProduct(int id)
        {
            bool isDeleted = false;
            isDeleted = await _productRepository.DeleteProduct(id);

            if (isDeleted)
            {
                return NoContent();
            }
            else {
                return NotFound("Product not found");
            }
        }
    }
}
