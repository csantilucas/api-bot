using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabelas disponíveis no Banco
        public DbSet<Client> PESSOA { get; set; }
        public DbSet<Ccr> UPAG_SIAPE { get; set; }
        public DbSet<Fatura> boleto_gerado{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Configuração da Tabela PESSOA ---
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("PESSOA");
                entity.HasKey(e => e.ID_CLIENTE);
                
                // Índice para busca rápida por CPF
                entity.HasIndex(c => c.CPF)
                      .HasDatabaseName("IX_PESSOA_CPF");
            });

            // --- Configuração da Tabela ccr ---
            modelBuilder.Entity<Ccr>(entity =>
            {
                entity.ToTable("UPAG_SIAPE");
                entity.HasKey(e => e.ID_UPAG);
            });
            //CONFIG tabela boletos_gerados
            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.ToTable("BOLETO_GERADO");
                entity.HasKey(e => e.ID_BOLETO_GERADO);
            });
        }
    }
}