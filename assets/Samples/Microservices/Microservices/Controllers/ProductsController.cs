using Microsoft.AspNetCore.Mvc;

namespace Microservices
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id) =>
            products.FirstOrDefault(p => p.Id == id) ?? (ActionResult<Product>)NotFound();

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return NoContent();
        }
    }
}