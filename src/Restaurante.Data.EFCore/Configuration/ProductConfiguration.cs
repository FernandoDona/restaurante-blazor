using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Data.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.EFCore.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(c => c.Name)
                .HasColumnType("nvarchar(70)");
            builder
                .Property(c => c.Description)
                .HasColumnType("nvarchar(500)");
            builder
                .Property<DateTime>("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder
                .Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasOne(p => p.Category);
        }
    }
}
