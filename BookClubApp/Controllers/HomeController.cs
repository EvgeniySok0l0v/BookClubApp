using BookClubApp.Entity;
using BookClubApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookClubApp.Controllers
{
    [Authorize]
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

        public IActionResult Index()
        {
            UserVM u = new UserVM(1, "xyz");
            return View(u);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddUser()
        {
            // ������� ������ ������������
            var user = new User("User1");
            

            // ��������� ������������ � �������� ���� ������
            _context.Users.Add(user);

            // ��������� ��������� � ���� ������
            _context.SaveChanges();

            return RedirectToAction("Index"); // �������������� �� ������ ��������
        }

        public IActionResult AddBook()
        {
            // ������� ����� �����
            var book = new Book("Title1");
          

            // ��������� ����� � �������� ���� ������
            _context.Books.Add(book);

            // ��������� ��������� � ���� ������
            _context.SaveChanges();

            return RedirectToAction("Index"); // �������������� �� ������ ��������
        }
    }
}
