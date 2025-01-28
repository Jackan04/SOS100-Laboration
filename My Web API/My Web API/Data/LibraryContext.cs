using Microsoft.EntityFrameworkCore;
using My_Web_API.Models;

namespace My_Web_API.Data 
{
    public class LibraryContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
    }
}