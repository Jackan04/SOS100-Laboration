using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        public IActionResult Create()
        {
            // Detta hämtar alla författare till sidan för att enklare kunna välja författare till en bok
            var authors = _context.Authors.ToList(); 
            ViewBag.Authors = new SelectList(authors, "AuthorID", "Name"); // Select lista som senare används i Vyn
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book) 
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Returnerar besökaren till Index-metoden/ sidan i samma controller
                
        }

    }
    

    
}