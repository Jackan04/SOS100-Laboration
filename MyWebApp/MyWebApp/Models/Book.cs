namespace MyWebApp.Models
{
    public class Book
    {
        public required int BookId { get; set; }
        public required string Title { get; set; }
        public required int PublishedYear { get; set; }
        
        // Före detta en främmande nyckel (ForeignKey) till Author
        public int AuthorID { get; set; }
        
        // Hämta ett Author-objekt av Author klassen
        public Author Author { get; set; }
    }
}