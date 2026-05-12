
using System.Data.Common;
using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options){}

        public DbSet<Client> PESSOA {get;set;}

        // index para a busca mais rapida
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Client>(entity =>{
                // Garante que o EF aponte para a tabela correta
                entity.ToTable("PESSOA"); 
                // Configura o índice para o CPF
                entity.HasIndex(c => c.CPF)
                      .HasDatabaseName("IX_PESSOA_CPF");
            });
            }
    }
}