using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatalogAPI.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using CatalogAPI.Entities;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IproductRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IproductRepository repository,
            ILogger<CatalogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string id)
        {
            var products = await _repository.GetProductById(id);

            if (products == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string Category)
        {
            var Product = await _repository.GetProductByCategory(Category);
            if (Product == null)
            {
                _logger.LogError($"Product with category: {Category}, not found.");
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct([FromBody] Product product)
        {
            await _repository.CreateProduct(product);
            return CreatedAtAction("CreateProduct", new { id = product.Id },product);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _repository.UpdateProduct(product));
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct([FromBody] string id)
        {
            return Ok(await _repository.DeleteProduct(id));
        }
    }

}