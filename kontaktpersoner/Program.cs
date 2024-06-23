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

// map get request to get kontaktPersoner by id from the database
app.MapGet("/get-kontaktPersoner-by-id/{kontaktId}", async (int kontaktId) =>
{
    KontaktPerson kToReturn = await KontaktPersonerRepository.GetKontaktByIdAsync(kontaktId);
    if (kToReturn != null)
    {
        return Results.Ok(kToReturn);
    }
    else
    {
        return Results.NotFound();
    }
    }).WithTags("KontaktPersoner Endpoints");

// map post request to add new kontaktPersoner to the database
app.MapPost("/add-kontaktPersoner", async (KontaktPersoner kontaktPersoner) => await KontaktPersonerRepository.AddKontaktPersonerAsync(kontaktPersoner))
    .WithTags("KontaktPersoner Endpoints");

// map put request to update kontaktPersoner by id in the database
app.MapPut("/update-kontaktPersoner/{id}", async (int id, KontaktPersoner kontaktPersoner) => await KontaktPersonerRepository.UpdateKontaktPersonerAsync(id, kontaktPersoner))
    .WithTags("KontaktPersoner Endpoints");

// map delete request to delete kontaktPersoner by id from the database
app.MapDelete("/delete-kontaktPersoner/{id}", async (int id) => await KontaktPersonerRepository.DeleteKontaktPersonerAsync(id))
    .WithTags("KontaktPersoner Endpoints");

app.Run();
