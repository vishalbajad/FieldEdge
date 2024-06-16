using AutoMapper;
using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.Services.Object_Provider;
using System.Net.Http;
using System.Net.Http;
using System.Threading.Tasks;

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
            var customersList = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<Customer>>(customersList);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var response = await _customerRepository.GetCustomerByIdAsync(customerId);
            return _mapper.Map<Customer>(response);
        }

        public async Task<HttpResponseMessage> AddCustomer(Customer newCustomer)
        {
            return await _customerRepository.AddCustomer(newCustomer);
        }

        public async Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer)
        {
            return await _customerRepository.UpdateCustomer(customerId, updatedCustomer);
        }

        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            return await _customerRepository.DeleteCustomer(customerId);
        }
    }
}