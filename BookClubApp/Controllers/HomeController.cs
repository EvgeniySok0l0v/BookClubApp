using BookClubApp.Entity;
using BookClubApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace BookClubApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        //private UserVM UserVM { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            UserVM u = new UserVM(1, "xyz");
            // Проверяем, аутентифицирован ли пользователь
            
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
            var allBooks = _context.Books.ToList();
            return View(allBooks);
        }

        public IActionResult ReadedBooks()
        {
            var userId = _context.Users.First(u => u.UserName == User.Identity.Name).Id;
            var userBooks = _context.UserBooks.Where(ub => ub.UserId == userId).ToList();
            
            var bookIds = new List<int>();
            userBooks.ForEach(ub => bookIds.Add(ub.BookId));

            var readedBooks = _context.Books.Where(b => bookIds.Contains(b.Id)).ToList();
            return View(readedBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddReadedBook(int bookId, string userName)
        {
            var userId = _context.Users.First(u => u.UserName == userName).Id;

            _context.UserBooks.Add(new UserBook(userId, bookId));
            _context.SaveChanges();

            return RedirectToAction("AllBooks", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReadedBook(int bookId, string userName)
        {
            var userId = _context.Users.First(u => u.UserName == userName).Id;
            
            _context.UserBooks.Where(ub => ub.UserId == userId && ub.BookId == bookId).ExecuteDelete();
  
            _context.SaveChanges();

            return RedirectToAction("ReadedBooks", "Home");
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
