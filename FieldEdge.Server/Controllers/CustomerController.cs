using AutoMapper;
using FieldEdge.Object_Provider;
using FieldEdge.Server.Services;
using FieldEdge.Services.Object_Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FieldEdge.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly AppSettingsConfigurations appSettingsConfigurations;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, IOptions<AppSettingsConfigurations> options, ILogger<CustomerController> logger, IWebHostEnvironment environment, ICustomerService customerService)
        {
            appSettingsConfigurations = options.Value;
            _customerService = customerService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Customers")]
        public IEnumerable<Customer> Get()
        {
            _logger.Log(LogLevel.Information, " Start Method Execution GetAllCustomers ");
            return _customerService.GetAllCustomers().Result;
        }

        [HttpGet("Customer/{id}")]
        public Customer Get(int id)
        {
            return _customerService.GetCustomerById(id).Result;
        }

        [HttpPost("Customer")]
        public Task<HttpResponseMessage> Post(Customer customer)
        {
            return _customerService.AddCustomer(customer);
        }

        [HttpPost("Customer/{id}")]
        public Task<HttpResponseMessage> UpdateCustomer(int id, Customer customer)
        {
            return _customerService.UpdateCustomer(id, customer);
        }

        [HttpDelete("Customer/{id}")]
        public Task<HttpResponseMessage> DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }
    }
}
