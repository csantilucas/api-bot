using api_bot.Data;
using Microsoft.EntityFrameworkCore;
using api_bot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Registrando o VendaService para que o Controller consiga usá-lo


builder.Services.AddScoped<FaturaServiceImp, FaturaService>();
builder.Services.AddScoped<ClientServiceImp, ClientService>();
builder.Services.AddScoped<ContratoServiceImp, ContratoService>();
builder.Services.AddScoped<CcrServiceImp, CcrService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();



var connectionString = builder.Configuration.GetConnectionString("appDbConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

 
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.UseSwaggerUI(options => 
    {
        
        options.SwaggerEndpoint("/openapi/v1.json", "Minha API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
