using BookClubApp.Entity;
using BookClubApp.Models;
using BookClubApp.Services;
using BookClubApp.Services.Imp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace BookClubApp.Controllers
{
    
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IBookService _bookService;
        //private UserVM UserVM { get; set; }

        public BookController(ILogger<BookController> logger, ApplicationDbContext context, IBookService bookService)
        {
            _logger = logger;
            _context = context;
            _bookService = bookService;
        }

        [Authorize]
        public IActionResult Index()
        {
            UserVM u = new UserVM(1, "xyz");
            // Проверяем, аутентифицирован ли пользователь
            var ui = User.Identity;
            if (!User.Identity.IsAuthenticated)
            {
                // Если пользователь не аутентифицирован, перенаправляем на страницу входа
                return RedirectToAction("Login", "Login");
            }

            // Если пользователь аутентифицирован, загружаем страницу Home
            return View(u);
        }

        public IActionResult AllBooks()
        {
            return View(_bookService.GetAllBooks(User.Identity.Name));
        }

        public IActionResult ReadedBooks()
        {
            return View(_bookService.GetReadedBooks(User.Identity.Name));
        }

        [HttpPost]
        public async Task<IActionResult> AddReadedBook(int bookId, string userName)
        {
            _bookService.AddToReadedBook(bookId, userName);

            return RedirectToAction("AllBooks", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReadedBook(int bookId, string userName)
        {
            _bookService.DeleteFromReadedBook(bookId, userName);

            return RedirectToAction("ReadedBooks", "Book");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddUser()
        {
            // Создаем нового пользователя
            //var user = new User("User1");
            var users = new List<User>() 
            {
                new User("User2"),
                new User("User3"),
                new User("User4"),
                new User("User5")
            };

            // Добавляем пользователя в контекст базы данных
            _context.Users.AddRange(users);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            return RedirectToAction("Index"); // Перенаправляем на другую страницу
        }

        public IActionResult AddBook()
        {
            // Создаем новую книгу
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


            // Добавляем книгу в контекст базы данных
            _context.Books.AddRange(books);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            return RedirectToAction("Index"); // Перенаправляем на другую страницу
        }
    }
}
