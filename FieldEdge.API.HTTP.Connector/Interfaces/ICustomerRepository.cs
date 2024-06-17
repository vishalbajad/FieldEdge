using FieldEdge.API.Object_Provider;
using System.Net.Http;

namespace FieldEdge.API.HTTP.Connector.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get all customers details
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetCustomers();

        /// <summary>
        /// Get Customer details by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerByIdAsync(int customerId);

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> AddCustomer(Customer newCustomer);

        /// <summary>
        /// Update Customers details
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="updatedCustomer"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> UpdateCustomer(int customerId, Customer updatedCustomer);

        /// <summary>
        /// Delete Customer 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> DeleteCustomer(int customerId);
    }
}
