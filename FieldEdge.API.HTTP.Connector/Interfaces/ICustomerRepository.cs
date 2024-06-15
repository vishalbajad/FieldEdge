using FieldEdge.API.Object_Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEdge.API.HTTP.Connector.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> AddCustomerAsync(Customer newCustomer);
        Task<Customer> UpdateCustomerAsync(int customerId, Customer updatedCustomer);
        Task DeleteCustomerAsync(int customerId);
    }

}
