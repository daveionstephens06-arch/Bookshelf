using Microsoft.AspNetCore.Mvc;
using Bookshelf.Models;

namespace Models.Controllers
{
    public class BookshelfController : Controller
    {
        private static List<Book> books_on_my_shelf = new List<Book>
        {
            new Book { Id = 1, Title = "Pride and Prejudice", Author = "Jane Austen", Pages = 376, IsRead = false },
            new Book { Id = 2, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180, IsRead = true },
            new Book { Id = 3, Title = "Animal Farm", Author = "George Orwell", Pages = 112, IsRead = true },
            new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, IsRead = true },
            new Book { Id = 5, Title = "1984", Author = "George Orwell", Pages = 328, IsRead = true },
            new Book { Id = 6, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Pages = 234, IsRead = false },
        };
        public IActionResult Books(string day)
        {
            ViewData["Title"] = "Books";
            ViewBag.Day = day;
            return View(books_on_my_shelf);
        }
        [HttpGet("books/{id:int}")]
        public IActionResult Details(int id)
        {
            foreach (Book each_book in books_on_my_shelf)
            {
                if (each_book.Id == id)
                {
                    ViewBag.LastId = books_on_my_shelf.Count;
                    return View(each_book);
                }
            }
            return NotFound();
        }
        [HttpGet("books/{id:int}/mark-read")]
        public IActionResult Mark(int id)
        {
            foreach (Book each_book in books_on_my_shelf)
            {
                if (each_book.Id == id)
                {
                    each_book.IsRead = true;
                    TempData["Message"] = $"Marked {each_book.Title} as read";
                    return RedirectToAction("Books");
                }
            }
            return NotFound();
        }
        [HttpGet("books/{id:int}/mark-unread")]
        public IActionResult MarkUnread(int id)
        {
            foreach (Book each_book in books_on_my_shelf)
            {
                if (each_book.Id == id)
                {
                    each_book.IsRead = false;

                    TempData["Message"] = $"Marked {each_book.Title} as unread";
                    return RedirectToAction("Books");
                }
            }
            return NotFound();
        }

    }
}