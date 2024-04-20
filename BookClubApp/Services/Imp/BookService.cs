using BookClubApp.Entity;
using BookClubApp.Models;
using BookClubApp.Mappers;
using Microsoft.EntityFrameworkCore;


namespace BookClubApp.Services.Imp
{
    public class BookService(ApplicationDbContext context) : IBookService
    {
        private readonly ApplicationDbContext _context = context;

        public void AddToReadedBook(int bookId, string userName)
        {
            _context.UserBooks.Add(new UserBook(GetUserId(userName), bookId));
            _context.SaveChanges();
        }

        public void DeleteFromReadedBook(int bookId, string userName)
        {
            _context.UserBooks.Where(ub => ub.UserId == GetUserId(userName) && ub.BookId == bookId).ExecuteDelete();
            _context.SaveChanges();
        }

        public IList<BookModel> GetAllBooks(string userName)
        {
            var readedBooks = GetReadedBooksFromDb(userName);

            return _context.Books
                .ToList()
                .Select(b => BookMapper.BookToBookModel(b, readedBooks.Contains(b)))
                .ToList();
        }

        public IList<BookModel> GetReadedBooks(string userName) => GetReadedBooksFromDb(userName)
                .Select(b => BookMapper.BookToBookModel(b, true))
                .ToList();

        private IList<Book> GetReadedBooksFromDb(string userName)
        {
            return [.. _context.Users
                .Where(u => u.UserName == userName)
                .SelectMany(u => u.UserBooks)
                .Select(ub => ub.Book)];
        }

        private int GetUserId(string userName) => _context.Users.First(u => u.UserName == userName).Id;
    }
}
