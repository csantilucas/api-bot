using api_bot.models;
using Microsoft.EntityFrameworkCore;

namespace api_bot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> PESSOA { get; set; }
        public DbSet<Ccr> UPAG_SIAPE { get; set; }
        public DbSet<Fatura> boleto_gerado { get; set; }
        public DbSet<Contrato> ALPHA_SETOR_CONTRATOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- PESSOA ---
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("PESSOA");
                entity.HasKey(e => e.ID_CLIENTE);
                entity.HasIndex(c => c.CPF).HasDatabaseName("IX_PESSOA_CPF");
            });

            // --- CONTRATOS (ALPHA_SETOR_CONTRATOS) ---
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("ALPHA_SETOR_CONTRATOS");
                entity.HasKey(e => e.ID_SETOR_CONTRATO);
                
            });

            // --- CCR (UPAG_SIAPE) ---
            modelBuilder.Entity<Ccr>(entity =>
            {
                entity.ToTable("UPAG_SIAPE");
                entity.HasKey(e => e.ID_UPAG);

                // Configuração da Relação 
                entity.HasOne(c => c.Cliente)           
                      .WithMany(p => p.Ccrs)            
                      .HasForeignKey(c => c.ID_CLIENTE);
            });

            // --- FATURA (BOLETO_GERADO) ---
            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.ToTable("BOLETO_GERADO");
                entity.HasKey(e => e.ID_BOLETO_GERADO);

                // Se quiser acessar c.Cliente dentro de Fatura também
                // entity.HasOne(f => f.Cliente)
                //       .WithMany() // Se não quiser criar uma lista de faturas no model Client, deixe vazio
                //       .HasForeignKey(f => f.ID_CLIENTE);
            });
        }
    }
}