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
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .Property<DateTime>("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder
                .Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            
            builder
                .HasKey(c => new { c.Id, c.UserId });
        }
    }
}
