using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelfLife.Data;
using ShelfLife.Models;

namespace ShelfLife.Controllers
{

    public class ReadingRecordController : Controller
    {
        private readonly LibraryContext _context;
        public ReadingRecordController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Details(int id)
        {
            var record = _context.ReadingRecords
                 .FirstOrDefault(r => r.ReadingRecordId == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        public IActionResult Create(int bookId )
        {
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]

        public IActionResult Create(ReadingRecord record)
        {           
            if (ModelState.IsValid)
            {
                _context.ReadingRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("Details", "Books", new {id = record.BookId});
            }
            return View(record);
        }

        public IActionResult Edit(int ReadingRecordId)
        {
            ViewBag.ReadingRecordId = ReadingRecordId;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, ReadingRecord newRecord)
        {
            
            var existingRecord = _context.ReadingRecords
                .FirstOrDefault(r => r.ReadingRecordId == id);
           
            if (existingRecord  == null)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                existingRecord.Status = newRecord.Status;
                existingRecord.Review = newRecord.Review;
                existingRecord.Rating = newRecord.Rating;
                existingRecord.DateStarted = newRecord.DateStarted;
                existingRecord.DateFinished = newRecord.DateFinished;

                _context.ReadingRecords.Update(existingRecord);  
                _context.SaveChanges();
                return RedirectToAction("Details", "Books", new { id = existingRecord.BookId });
            }
            return View(newRecord);
        }
        public IActionResult Delete(int id)
        {
            var record = _context.ReadingRecords
                 .FirstOrDefault(r => r.ReadingRecordId == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        public IActionResult DeleteConfirned(int id)
        {
            var record = _context.ReadingRecords
                .FirstOrDefault(r => r.ReadingRecordId == id);
           
            if (record == null)
            {
                return NotFound();
            }
            _context.ReadingRecords.Remove(record);
            _context.SaveChanges();
            return RedirectToAction("Details", "Books", new { id = record.BookId });
        }

    }   
}
