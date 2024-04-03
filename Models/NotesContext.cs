using Microsoft.EntityFrameworkCore;

namespace StickyNotesDemo.Models
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes
        {
            get; set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Notes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasKey(n => n.Id);
        }
    }
}
