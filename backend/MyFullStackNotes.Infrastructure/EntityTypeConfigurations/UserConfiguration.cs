using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFullStackNotes.Domain.Entities;

namespace MyFullStackNotes.Infrastructure.EntityTypeConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasIndex(u => u.Email).IsUnique();
            
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(10)
                .HasConversion<string>();

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
