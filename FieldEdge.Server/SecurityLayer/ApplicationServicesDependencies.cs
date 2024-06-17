using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.HTTP.Connector.Repositories;
using FieldEdge.API.Object_Provider;
using FieldEdge.Object_Provider;
using FieldEdge.Server.SecurityLayer;
using FieldEdge.Server.Services;
using System.Net.Http.Headers;

namespace FieldEdge.Server.SecurityLayer
{
    public static class ApplicationServicesDependencies
    {
        public static void AddApplicationServicesDependencies(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Program));
            services.AddScoped<IHttpRepository<Customer>, HttpRepository<Customer>>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddHttpClient<IHttpRepository<Customer>, HttpRepository<Customer>>("FieldEdge", client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
