using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }

        // Hämta listan med författare
        public async Task<IActionResult> Index()
        {
            // Hämta Författare från databasen och lägg de i varaibeln "authors"
            var authors = await _context.Authors.ToListAsync();
            return View(authors); 
        }
        
        // Hämta vyn för att skapa en författare
        public IActionResult Create()
        {
            return View(); 
        }

        // Skicka det till databasen

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
          
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            
            
            /*return View(author); // Om ett fel uppstår visas formuläret på nytt*/
        }

        


    }
}