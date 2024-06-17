using AutoMapper;
using FieldEdge.Server.Services;
using FieldEdge.Services.Object_Provider;
using Microsoft.AspNetCore.Mvc;

namespace FieldEdge.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet("Customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            _logger.LogInformation("Fetching all customers");

            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("Customer/{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            _logger.LogInformation("Fetching customer with ID {Id}", id);

            var customer = await _customerService.GetCustomerById(id);

            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost("Customer")]
        public async Task<ActionResult<HttpResponseMessage>> Post(Customer customer)
        {
            _logger.LogInformation("Adding a new customer");

            var response = await _customerService.AddCustomer(customer);

            if (!response.IsSuccessStatusCode) return this.BadRequest();

            return Ok(response);
        }

        [HttpPost("Customer/{id}")]
        public async Task<ActionResult<HttpResponseMessage>> UpdateCustomer(int id, Customer customer)
        {
            _logger.LogInformation("Updating customer with ID {Id}", id);

            if (id != customer.Id) return BadRequest("ID mismatch between route parameter and request body.");

            var response = await _customerService.UpdateCustomer(id, customer);

            if (!response.IsSuccessStatusCode) return BadRequest();

            return NoContent();
        }

        [HttpDelete("Customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting customer with ID {Id}", id);

            var response = await _customerService.DeleteCustomer(id);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
