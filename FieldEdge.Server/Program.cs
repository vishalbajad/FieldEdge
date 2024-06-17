using FieldEdge.Object_Provider;
using FieldEdge.Server.SecurityLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

string originConfigValue = builder.Configuration["SystemConfigurations:Origins"];
string APIServerPassword = builder.Configuration["SystemConfigurations:APIServerPassword"];

builder.Services.Configure<AppSettingsConfigurations>(builder.Configuration.GetSection("SystemConfigurations"));
builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.WithOrigins(originConfigValue.Split(";")).AllowAnyHeader().AllowAnyMethod(); }); });

builder.Services.AddApplicationServicesDependencies();
builder.Services.AddRateLimitingServices();
builder.Services.AddAuthenticationsServices(APIServerPassword);

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

app.UseRateLimiter();

app.UseCors();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.MapFallbackToFile("/index.html");

app.Run();
