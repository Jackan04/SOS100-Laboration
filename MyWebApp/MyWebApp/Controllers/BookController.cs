using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        
        public BookController(AppDbContext context)
        {
            _context = context;
        }

        // Hämta listan med Böcker
        public async Task<IActionResult> Index()
        {
            // Hämta alla böcker med deras författare från databasen
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            return View(books); // Skickar böckerna till vyn
        }
        


    }
}