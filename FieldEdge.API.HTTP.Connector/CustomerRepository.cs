using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.Object_Provider;
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

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("customers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var response = await _httpClient.GetAsync($"customers/{customerId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<Customer> AddCustomerAsync(Customer newCustomer)
        {
            var response = await _httpClient.PostAsJsonAsync("customers", newCustomer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<Customer> UpdateCustomerAsync(int customerId, Customer updatedCustomer)
        {
            var response = await _httpClient.PutAsJsonAsync($"customers/{customerId}", updatedCustomer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var response = await _httpClient.DeleteAsync($"customers/{customerId}");
            response.EnsureSuccessStatusCode();
        }
    }

}
