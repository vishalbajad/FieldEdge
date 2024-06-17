using FieldEdge.API.HTTP.Connector;
using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.HTTP.Connector.Repositories;
using FieldEdge.Object_Provider;
using FieldEdge.Server.Services;
using FieldEdge.API.Object_Provider;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettingsConfigurations>(builder.Configuration.GetSection("SystemConfigurations"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IHttpRepository<Customer>, HttpRepository<Customer>>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddHttpClient<IHttpRepository<Customer>, HttpRepository<Customer>>("FieldEdge", client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});


// Default Policy
builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.WithOrigins("https://localhost:7190", "https://localhost:5173").AllowAnyHeader().AllowAnyMethod(); }); });

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
