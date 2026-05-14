using api_bot.Data;
using Microsoft.EntityFrameworkCore;
using api_bot.Configuration; // Ponto e vírgula adicionado
using Microsoft.AspNetCore.Mvc.ApplicationModels; // Necessário para o RouteTokenTransformer

var builder = WebApplication.CreateBuilder(args);

// 1. Configura os Controllers com o Prefixo "api"
builder.Services.AddControllers();

// 2. Central de Injeção de Dependência
builder.Services.AddProjectServices(); 

// 3. Banco de Dados
var connectionString = builder.Configuration.GetConnectionString("appDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configurações de Middleware (Swagger, Auth, etc)
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

