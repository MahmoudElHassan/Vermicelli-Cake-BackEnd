using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_DAL;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        //builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureURL).IsRequired();
        builder.HasOne(p => p.category).WithMany()
            .HasForeignKey(p => p.CategoryId);
        //builder.HasOne(p => p.flavor).WithMany()
        //    .HasForeignKey(p => p.FlavorId);
    }
}