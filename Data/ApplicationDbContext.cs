using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Category> Categories { get; set; }

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<Customer>().HasOne(x => x.User).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}