using FieldEdge.API.HTTP.Connector;
using FieldEdge.API.HTTP.Connector.Interfaces;
using FieldEdge.API.HTTP.Connector.Repositories;
using FieldEdge.Server.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var configurations = builder.Configuration.GetSection("SystemConfigurations");

builder.Services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<ICustomerRepository, CustomerRepository>("FieldEdge", client =>
{
    client.BaseAddress = new Uri(configurations["APIServerBaseUrl"].ToString());
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICustomerService, CustomerService>();

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
