namespace ShelfLife.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DatePublished { get; set; }
        public required string CoverUrl { get; set; }
        public ReadingRecord ReadingRecord { get; set; }

        // Navigation properties
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
       
    }
}
