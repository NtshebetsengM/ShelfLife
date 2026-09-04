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

        public IActionResult Edit(int id)
        {
            var book = _context.Books
                .FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            var existingBook = _context.Books
                .FirstOrDefault(b => b.BookId == id); 
           
            if (existingBook == null) {
                return NotFound();
            }
                if (ModelState.IsValid)
                {
                    _context.Books.Update(existingBook);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(book);
        }
    }
}
