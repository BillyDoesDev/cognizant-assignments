using Microsoft.EntityFrameworkCore;

namespace RetailInventory.Models;

public class AppDbContext : DbContext {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=RetailDB;User Id=sa;Password=EightCharsLong_069;TrustServerCertificate=True;");
    }

}
