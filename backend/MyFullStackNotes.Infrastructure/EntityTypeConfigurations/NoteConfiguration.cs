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
    class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(n => n.Description)
                   .HasMaxLength(1000);

            builder.Property(n => n.CreatedAt)
                   .IsRequired();

            builder.Property(n => n.UserId)
                   .IsRequired();

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

        }
    }
}
