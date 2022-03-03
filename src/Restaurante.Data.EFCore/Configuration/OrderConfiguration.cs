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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder
                .Property(o => o.DeliveredAt)
                .HasColumnType("datetime");
            builder
                .Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasKey(o => new { o.Id, o.UserId });
            builder
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders);
            builder
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);
        }
    }
}
