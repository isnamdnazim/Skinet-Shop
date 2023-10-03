using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.ProductDescription).IsRequired();
            builder.Property(p=>p.ProductPrice).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.ProductImageUrl).IsRequired();
            builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(t=>t.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}