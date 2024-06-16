using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.Services.Object_Provider;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FieldEdge.API.HTTP.Connector
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient _httpClient;

        public CustomerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://getinvoices.azurewebsites.net/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("customers");
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var response = await _httpClient.GetFromJsonAsync<Customer>($"customer/{customerId}");
            return response;
        }

        public async Task<HttpResponseMessage> AddCustomer(Customer newCustomer)
        {
            var response = await _httpClient.PostAsJsonAsync("customers", newCustomer);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer)
        {
            return await _httpClient.PutAsJsonAsync($"customers/{customerId}", updatedCustomer);
        }

        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            return await _httpClient.DeleteAsync($"customers/{customerId}");
        }
    }
}
