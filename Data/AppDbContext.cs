
using System.Data.Common;
using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){}

        public DbSet<Client> PESSOA {get;set;}
    }
}