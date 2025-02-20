using Microsoft.EntityFrameworkCore;

namespace Api.Models 
{
public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente>  Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(b =>
            {
                b.ToTable("TB_CLIENTE", schema: "public");
            });

        }        
    }
}   