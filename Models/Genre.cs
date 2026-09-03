namespace ShelfLife.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
