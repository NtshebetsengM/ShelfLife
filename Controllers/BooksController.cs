using Microsoft.AspNetCore.Mvc;
using ShelfLife.Data;
using ShelfLife.Models;

namespace ShelfLife.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books
                .FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = _context.Authors.ToList();
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book, List<int> SelectedAuthorIds, List<int> SelectedGenreIds, string NewAuthorName)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();

                if (!string.IsNullOrEmpty(NewAuthorName))
                {
                    var newAuthor = new Author { Name = NewAuthorName };
                    _context.Authors.Add(newAuthor);
                    _context.SaveChanges();
                    SelectedAuthorIds.Add(newAuthor.AuthorId);
                }

                foreach (var authorId in SelectedAuthorIds)
                {
                    _context.BookAuthors.Add(new BookAuthor
                    {
                        BookId = book.BookId,
                        AuthorId = authorId
                    });
                }

                foreach (var genreId in SelectedGenreIds)
                {
                    _context.BookGenres.Add(new BookGenre
                    {
                        BookId = book.BookId,
                        GenreId = genreId
                    });
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
