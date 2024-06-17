using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.Object_Provider;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FieldEdge.API.HTTP.Connector.Repositories
{
    /// <summary>
    /// Customer Repository
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient _httpClient;

        public CustomerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get all customers details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("customers");
            return customers;
        }
        /// <summary>
        /// Get Customer details by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var response = await _httpClient.GetFromJsonAsync<Customer>($"customer/{customerId}");
            return response;
        }
        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> AddCustomer(Customer newCustomer)
        {
            var response = await _httpClient.PostAsJsonAsync("customer", newCustomer);
            return response;
        }
        /// <summary>
        /// Update Customers details
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="updatedCustomer"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer)
        {
            return await _httpClient.PostAsJsonAsync($"customer/{customerId}", updatedCustomer);
        }
        /// <summary>
        /// Delete Customer 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            return await _httpClient.DeleteAsync($"customer/{customerId}");
        }
    }
}
