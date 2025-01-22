namespace MyWebApp.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        
        // Hämta alla böcker kopplat till en författare
        public List<Book> Books { get; set; }
    }
}