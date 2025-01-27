using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
        
        public AuthorController(AppDbContext context) // Skapa en instans av databasen för att använda den
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
        
        // Hämta View med formulär för att skapa en författare
        public IActionResult Create()
        {
            return View(); 
        }
        
        // Skicka formuläret till databasen

        [HttpPost]
        public async Task<IActionResult> Create(Author author) 
        {
          
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Returnerar besökaren till Index-metoden/ sidan i samma controller
                
        }
        
        // Skicka sidan för att radera en författare
        [HttpGet]
        public IActionResult Delete()
        {
            var authors = _context.Authors.ToList(); // Hämta alla författare från databasen och lägg de i en lista
            return View(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int AuthorID)
        {
            var author = await _context.Authors.FindAsync(AuthorID);
            
            if (author == null)
            {
                return NotFound(); 
            }
            
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Returnerar besökaren till Index-metoden/ sidan i samma controller
        }

        
        [HttpGet]
        public async Task<IActionResult> Update(int id) // Hämtar den valda författaren efter ID
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound(); 
            }

            return View(author); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(Author author)
        {
            
                _context.Authors.Update(author); 
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index)); 
            
        }




    }
}