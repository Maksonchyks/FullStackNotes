using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyFullStackNotes.Infrastructure.Data
{
    class NotesDbContextFactory : IDesignTimeDbContextFactory<NotesDbContext>
    {
        public NotesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotesDbContext>();
            var connectionString = "Server=localhost;Database=Notes;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new NotesDbContext(optionsBuilder.Options);
        }
    }
}
