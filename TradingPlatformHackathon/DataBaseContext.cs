using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon;

public class DataBaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<PurchaseRequest> PurchaseRequests { get; set; } = null!;

    public DataBaseContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(x => x.RoleId);
        
        modelBuilder.Entity<Role>()
            .Property(x => x.Name)
            .HasConversion<string>();

        modelBuilder.Entity<Role>()
            .HasData(new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    Name = "admin"
                },
                new Role()
                {
                    Id = 2,
                    Name = "buyer"
                },
                new Role()
                {
                    Id = 3,
                    Name = "supplier"
                }
            });
        modelBuilder.Entity<PurchaseRequest>()
            .HasOne(p => p.Buyer)
            .WithMany(b => b.PurchaseRequestsAsBuyer)
            .HasForeignKey(x => x.BuyerId);

        modelBuilder.Entity<PurchaseRequest>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.PurchaseRequestsAsSupplier)
            .HasForeignKey(x => x.SupplierId);
        
        modelBuilder.Entity<PurchaseResponse>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.PurchaseResponses)
            .HasForeignKey(x => x.SupplierId);

        modelBuilder.Entity<PurchaseResponse>()
            .HasOne(x => x.PurchaseRequest)
            .WithMany(y => y.PurchaseResponses)
            .HasForeignKey(z => z.PurchaseRequestId);
    }
}