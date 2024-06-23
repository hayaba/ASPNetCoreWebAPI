using kontaktpersoner.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptionsExtensions =>
{
    SwaggerGenOptionsExtensions.SwaggerDoc("v1", new OpenApiInfo { Title = "kontaktpersoner list", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(SwaggerUIOptions =>
{
    SwaggerUIOptions.DocumentTitle = "kontaktpersoner list";
    SwaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "kontaktpersoner list v1");
    SwaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

// map get request to get all kontaktPersoner from the database 
app.MapGet("/get-all-kontaktPersoner", async () => await KontaktPersonerRepository.GetKontaktPersonerAsync())
    .WithTags("KontaktPersoner Endpoints");

app.Run();
