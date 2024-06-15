using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.HTTP.Connector;
using FieldEdge.Object_Provider;
using FieldEdge.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettingsConfigurations>(builder.Configuration.GetSection("SystemConfigurations"));
builder.Services.AddHttpClient<ICustomerRepository, CustomerRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICustomerService, CustomerService>(); 

var app = builder.Build();

app.UseExceptionHandler("/Error");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
