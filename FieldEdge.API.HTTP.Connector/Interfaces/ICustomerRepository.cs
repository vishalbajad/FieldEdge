using FieldEdge.Services.Object_Provider;

namespace FieldEdge.API.HTTP.Connector.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<HttpResponseMessage> AddCustomer(Customer newCustomer);
        Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer);
        Task<HttpResponseMessage> DeleteCustomer(int customerId);
    }
}
