using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs.Requests;
using WebApplication1.Services.Interfaces;
using WebApplication1.Services.Implementations;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service = new ProductService();

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreateDto dto)
        {
            var created = _service.CreateProduct(dto);
            return Created($"/products/{created.Id}", created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductForUpdateDto dto)
        {
            var existing = _service.GetProductById(id);
            if (existing == null) return NotFound();

            _service.UpdateProduct(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existing = _service.GetProductById(id);
            if (existing == null) return NotFound();

            _service.DeleteProduct(id);
            return NoContent();
        }
    }
}