using AutoMapper;
using FieldEdge.API.HTTP.Connector.Interfaces;
using Services_Object_Provider = FieldEdge.Services.Object_Provider;
using API_Object_Provider = FieldEdge.API.Object_Provider;
using System.Net.Http;
using System.Net.Http;
using System.Threading.Tasks;
using FieldEdge.Object_Provider;
using System;
using Microsoft.Extensions.Options;

namespace FieldEdge.Server.Services
{
    /// <summary>
    /// Customer Service for Communications
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IHttpRepository<API_Object_Provider.Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly AppSettingsConfigurations _appSettingsConfigurations;

        public CustomerService(IHttpRepository<API_Object_Provider.Customer> customerRepository, IMapper mapper, IOptions<AppSettingsConfigurations> options)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _appSettingsConfigurations = options.Value;
        }

        /// <summary>
        /// Get all customers Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Services_Object_Provider.Customer>> GetAllCustomers()
        {
            var customersList = await _customerRepository.Get(GenerateWelUrls(_appSettingsConfigurations.APIServerBaseUrl, "customers"));
            return _mapper.Map<IEnumerable<Services_Object_Provider.Customer>>(customersList);
        }

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Services_Object_Provider.Customer> GetCustomerById(int customerId)
        {
            var customer = await _customerRepository.GetSingle(GenerateWelUrls(_appSettingsConfigurations.APIServerBaseUrl, "customer", customerId.ToString()));
            return _mapper.Map<Services_Object_Provider.Customer>(customer);
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AddCustomer(Services_Object_Provider.Customer newCustomer)
        {
            var apicustomer = _mapper.Map<API_Object_Provider.Customer>(newCustomer);
            return await _customerRepository.Add(GenerateWelUrls(_appSettingsConfigurations.APIServerBaseUrl, "customer"), apicustomer);
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
            return await _customerRepository.Update(GenerateWelUrls(_appSettingsConfigurations.APIServerBaseUrl, "customer", customerId.ToString()), apicustomer);
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            return await _customerRepository.Delete(GenerateWelUrls(_appSettingsConfigurations.APIServerBaseUrl, "customer", customerId.ToString()));
        }

        private static string GenerateWelUrls(params string[] parameters)
        {
            UriBuilder uriBuilder = new UriBuilder(Path.Combine(parameters));
            return uriBuilder.ToString();
        }
    }
}