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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));         
        }
    }
}
