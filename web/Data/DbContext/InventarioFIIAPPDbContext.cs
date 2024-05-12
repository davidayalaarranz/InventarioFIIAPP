using InventarioFIIAPP.Data.Models;
using Microsoft.EntityFrameworkCore;

public class InventarioFIIAPPDbContext: DbContext {
public InventarioFIIAPPDbContext (DbContextOptions<InventarioFIIAPPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
		
		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>().ToTable("Usuario");
		}
}