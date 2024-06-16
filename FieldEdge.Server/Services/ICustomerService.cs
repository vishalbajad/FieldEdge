using FieldEdge.Services.Object_Provider;
using System.Net.Http;

namespace FieldEdge.Server.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers Details
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAllCustomers();

        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<Customer> GetCustomerById(int customerId);

        /// <summary>
        /// Create new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> AddCustomer(Customer newCustomer);

        /// <summary>
        /// Update existings customer details
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
