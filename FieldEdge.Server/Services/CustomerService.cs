using AutoMapper;
using FieldEdge.API.HTTP.Connector.Interfaces;
using Services_Object_Provider = FieldEdge.Services.Object_Provider;
using API_Object_Provider = FieldEdge.API.Object_Provider;
using System.Net.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace FieldEdge.Server.Services
{
    /// <summary>
    /// Customer Service for Communications
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all customers Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Services_Object_Provider.Customer>> GetAllCustomers()
        {
            var customersList = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<Services_Object_Provider.Customer>>(customersList);
        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Services_Object_Provider.Customer> GetCustomerById(int customerId)
        {
            var response = await _customerRepository.GetCustomerByIdAsync(customerId);
            return _mapper.Map<Services_Object_Provider.Customer>(response);
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AddCustomer(Services_Object_Provider.Customer newCustomer)
        {
            var apicustomer = _mapper.Map<API_Object_Provider.Customer>(newCustomer);
            return await _customerRepository.AddCustomer(apicustomer);
        }

        /// <summary>
        /// Update existings customer details
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="updatedCustomer"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateCustomer(int customerId, Services_Object_Provider.Customer updatedCustomer)
        {
            var apicustomer = _mapper.Map<API_Object_Provider.Customer>(updatedCustomer);
            return await _customerRepository.UpdateCustomer(customerId, apicustomer);
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            return await _customerRepository.DeleteCustomer(customerId);
        }
    }
}