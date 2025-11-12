using Microsoft.EntityFrameworkCore;

public class ContactosContext : DbContext
{
    public DbSet<Contacto> Contactos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; } 

    public ContactosContext(DbContextOptions<ContactosContext> options)
        : base(options)
    {
    }

    public ContactosContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=SQL8020.site4now.net;Database=db_a358b2_pam3;User Id=db_a358b2_pam3_admin;Password=tudai123;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Contacto>().ToTable("Contacto");
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
    }
}
