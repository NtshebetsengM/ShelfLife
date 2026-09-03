namespace ShelfLife.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public Genre Genre { get; set; }

    }
}
