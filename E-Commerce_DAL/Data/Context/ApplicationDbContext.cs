using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace E_Commerce_DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
    {
    }


    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                }
            }
        }
    }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            var entity = entry.Entity;

            if (entry.State == EntityState.Deleted) //&& entity is ISoftDelete
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, true);
            }
            else
            {
                entry.State = EntityState.Modified;
                entity.GetType().GetProperty("IsDelete")?.SetValue(entity, false);
            }

        }
        return base.SaveChanges();
    }
}
