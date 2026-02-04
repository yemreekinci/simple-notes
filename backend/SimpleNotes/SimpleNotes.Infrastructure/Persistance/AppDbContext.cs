using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleNotes.Domain.Entities.Content;

namespace SimpleNotes.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Configurations.NoteConfiguration());
        }
    }
}

