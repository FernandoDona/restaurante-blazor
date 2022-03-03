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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .Property(a => a.Street)
                .HasColumnType("nvarchar(100)");
            builder
                .Property(a => a.Number)
                .HasColumnType("nvarchar(10)");
            builder
                .Property(a => a.Neighborhood)
                .HasColumnType("nvarchar(50)");
            builder
                .Property(a => a.City)
                .HasColumnType("nvarchar(50)");
            builder
                .Property(a => a.ZipCode)
                .HasColumnType("nvarchar(15)");
            builder
                .Property(a => a.Complement)
                .HasColumnType("nvarchar(200)");
            builder
                .Property<DateTime>("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
            builder
                .Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasKey(a => a.UserId);
            builder
                .HasOne(a => a.User)
                .WithOne(u => u.Address);
        }
    }
}
