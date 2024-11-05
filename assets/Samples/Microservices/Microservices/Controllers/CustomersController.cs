using Microsoft.AspNetCore.Mvc;

namespace Microservices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>();

        [HttpGet]
        public IEnumerable<Customer> Get() => customers;

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id) =>
            customers.FirstOrDefault(c => c.Id == id) ?? (ActionResult<Customer>)NotFound();

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }
    }
}