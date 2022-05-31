using System.Diagnostics;
using BookApp.Models;
using BookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly BookService bookService;
        public HomeController(BookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
                try
                {
                    IEnumerable<Book> books = await bookService.GetBooks();
                ViewBag.book = true;
                if (books.Count() == 0)
                    {
                        ViewBag.book = false;
                        return View(books);
                    }
                    else
                    {
                        return View(books);
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return View();
                }
              
        }

        [HttpPost]
        public async Task<IActionResult> Index(Book book)
        {
            Book newBook = book;
            await bookService.CreateBook(newBook);
            return RedirectToAction("Index");
        }
        
       
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book updatedBook)
        {
            if (updatedBook is null)
            {
                return View();
            }
            var book = await bookService.GetBook(updatedBook.Id);

            if (book is null)
            {
                return View();
            }
            await bookService.UpdateBook(updatedBook.Id, updatedBook);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(string id)
        {
            await bookService.DeleteBook(id);
            var books = await bookService.GetBooks();
            
            return RedirectToAction("Index");

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}