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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(c => c.Name)
                .HasColumnType("nvarchar(50)");
            builder
                .Property(c => c.Email)
                .HasColumnType("nvarchar(70)");
            builder
                .Property(c => c.Phone)
                .HasColumnType("nvarchar(20)");
            builder
                .Property<DateTime>("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder
                .Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            
            builder
                .HasIndex(c => c.Email)
                .IsUnique();
            builder
                .HasIndex(c => c.Phone)
                .IsUnique();
            builder
                .HasIndex(u => u.Token)
                .IsUnique();
            builder
                .HasIndex(u => u.Name);
        }
    }
}
