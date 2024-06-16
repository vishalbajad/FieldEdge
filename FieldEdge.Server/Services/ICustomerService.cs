using FieldEdge.Services.Object_Provider;
using System.Net.Http;

namespace FieldEdge.Server.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task<HttpResponseMessage> AddCustomer(Customer newCustomer);
        Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer);
        Task<HttpResponseMessage> DeleteCustomer(int customerId);
    }
}
