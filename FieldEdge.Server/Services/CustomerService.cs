using AutoMapper;
using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.Services.Object_Provider;

namespace FieldEdge.Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customersList = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<IEnumerable<Customer>>(customersList);
        }
    }
}
