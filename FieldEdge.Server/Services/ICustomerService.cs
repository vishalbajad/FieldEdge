using FieldEdge.Services.Object_Provider;

namespace FieldEdge.Server.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
