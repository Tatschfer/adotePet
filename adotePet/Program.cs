using adotePet.Repositories;
using adotePet.Services;
using MySqlConnector;
using Scalar.AspNetCore;
using System.Data;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Banco
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbConnection>(_ => new MySqlConnection(conn));

// Repositories
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IDoadorRepository, DoadorRepository>(); 

//// Services - business rules - add dps
//builder.Services.AddScoped<IPetService, PetService>(); 
//builder.Services.AddScoped<IDoadorService, DoadorService>();

// Scalar - tipo o swagger, testando :)
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    
    app.MapOpenApi();

    //http://localhost:XXXX/scalar/v1
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();