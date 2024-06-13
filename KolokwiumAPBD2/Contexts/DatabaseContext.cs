using Microsoft.EntityFrameworkCore;

namespace KolokwiumAPBD2.Contexts;

public class DatabaseContext : DbContext
{
    
    //tutaj DbSet<>
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //tutaj dodanie elementów do tabel
    }
}