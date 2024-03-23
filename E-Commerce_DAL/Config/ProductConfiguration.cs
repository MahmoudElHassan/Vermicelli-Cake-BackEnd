using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_DAL;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.PictureURL).IsRequired();
        builder.HasOne(p => p.productBrand).WithMany()
            .HasForeignKey(p => p.ProductBrandId);
        builder.HasOne(p => p.productType).WithMany()
            .HasForeignKey(p => p.ProductTypeId);
    }
}