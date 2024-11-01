using Microsoft.AspNetCore.Mvc;
using WebShop.UnitOfWork;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        // Endpoint för att hämta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Behöver använda repository via Unit of Work för att hämta produkter
            return Ok();
        }

        // Endpoint för att lägga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            // Lägger till produkten via repository

            // Sparar förändringar

            // Notifierar observatörer om att en ny produkt har lagts till

            return Ok();
        }
    }
}
