using ConnectDatabaseAndSimpleApi.Controllers;
using ConnectDatabaseAndSimpleApi.Entites;
using hai123.Entities;
using Microsoft.EntityFrameworkCore;

namespace hai123.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseOrder>()
            .HasMany(x => x.PurchaseOrderLines)
            .WithOne()
            .HasForeignKey(x => x.FatherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Fish> Fish { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
}