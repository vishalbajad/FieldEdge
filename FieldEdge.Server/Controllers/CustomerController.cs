using AutoMapper;
using FieldEdge.Object_Provider;
using FieldEdge.Server.Services;
using FieldEdge.Services.Object_Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FieldEdge.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            _logger.Log(LogLevel.Information, " Start Method Execution GetAllCustomers ");
            return _customerService.GetAllCustomers().Result;
        }
    }
}
