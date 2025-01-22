using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definierar relationen mellan Book och Author
                modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) // En book har en Author
                .WithMany(a => a.Books) // En Author kan ha många Books
                .HasForeignKey(b => b.AuthorID) // Använd AuthorID som foreign key
                .OnDelete(DeleteBehavior.Restrict); // Om en författare tas bort, ta inte bort böckerna
        }
    }
}