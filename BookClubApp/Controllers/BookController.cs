using BookClubApp.Models;
using BookClubApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookClubApp.Controllers
{
    /// <summary>
    /// Book controller
    /// </summary>
    public class BookController(ILogger<BookController> logger, ApplicationDbContext context, IBookService bookService) : Controller
    {
        private readonly ILogger<BookController> _logger = logger;
        private readonly ApplicationDbContext _context = context;
        private readonly IBookService _bookService = bookService;

        [Authorize]
        public IActionResult Index()
        {
            _logger.LogInformation("Start page");
            return View();
        } 

        [Authorize]
        public IActionResult AllBooks()
        {
            _logger.LogInformation("All books page");
            return View(_bookService.GetAllBooks(User.Identity.Name));
        }

        [Authorize]
        public IActionResult ReadedBooks()
        {
            _logger.LogInformation($"Readed books for {User.Identity.Name}");
            return View(_bookService.GetReadedBooks(User.Identity.Name));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBookToReaded(int bookId, string userName)
        {
            _bookService.AddToReadedBook(bookId, userName);
            _logger.LogInformation($"Book {bookId} was added");
            return RedirectToAction("AllBooks", "Book");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteBookFromReaded(int bookId, string userName)
        {
            _bookService.DeleteFromReadedBook(bookId, userName);
            _logger.LogInformation($"Book {bookId} was deleted");
            return RedirectToAction("ReadedBooks", "Book");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /**
         * просто так добавил юзеров и книги в бд
         * 
         * 
        public IActionResult AddUser()
        {
            
            var users = new List<User>() 
            {
                new User("User1"),
                new User("User2"),
                new User("User3"),
                new User("User4"),
                new User("User5")
            };


            _context.Users.AddRange(users);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }

        public IActionResult AddBook()
        {
            var books = new List<Book>()
            {
                new Book("Title1"),
                new Book("Title2"),
                new Book("Title3"),
                new Book("Title4"),
                new Book("Title5"),
                new Book("Title6"),
                new Book("Title7"),
                new Book("Title8"),
                new Book("Title9"),
                new Book("Title10"),
            };

            _context.Books.AddRange(books);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }*/
    }
}
