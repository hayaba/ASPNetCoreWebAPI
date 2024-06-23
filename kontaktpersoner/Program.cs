using kontaktpersoner.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .WithOrigins("http://localhost:3000", "https://https://appname.azurestaticapps.net");
        });
});

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

app.UseCors("CORSPolicy");

// map get request to get all kontaktPersoner from the database 
app.MapGet("/get-all-kontaktPersoner", async () => await KontaktPersonerRepository.GetKontaktPersonerAsync())
    .WithTags("KontaktPersoner Endpoints");

// map get request to get kontaktPersoner by id from the database
app.MapGet("/get-kontaktPersoner-by-id/{kontaktId}", async (int kontaktId) =>
{
    KontaktPerson k = await KontaktPersonerRepository.GetKontaktByIdAsync(kontaktId);
    if (k != null)
    {
        return Results.Ok(k);
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("KontaktPersoner Endpoints");

// map post request to add new kontaktPersoner to the database
app.MapPost("/create-kontaktPersoner", async (KontaktPerson kontaktToCreate) =>
{
    bool created = await KontaktPersonerRepository.CreateKontaktAsync(kontaktToCreate);
    if (created)
    {
        return Results.Ok("Create Successful!!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("KontaktPersoner Endpoints");

// map put request to update kontaktPersoner in the database
app.MapPut("/update-kontaktPersoner", async (KontaktPerson kontaktToUpdate) =>
{
    bool updated = await KontaktPersonerRepository.UpdateKontaktAsync(kontaktToUpdate);
    if (updated)
    {
        return Results.Ok("Update Successful!!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("KontaktPersoner Endpoints");

// map delete request to delete kontaktPersoner by id from the database
app.MapDelete("/delete-kontaktPersoner/{kontaktId}", async (int kontaktId) =>
{
    bool deleted = await KontaktPersonerRepository.DeleteKontaktAsync(kontaktId);
    if (deleted)
    {
        return Results.Ok("Delete Successful!!");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("KontaktPersoner Endpoints");

app.Run();
