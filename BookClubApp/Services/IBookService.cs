using BookClubApp.Models;


namespace BookClubApp.Services
{
    public interface IBookService
    {
        IList<BookModel> GetAllBooks(string userName);

        IList<BookModel> GetReadedBooks(string userName);

        void AddToReadedBook(int bookId, string userName);

        void DeleteFromReadedBook(int bookId, string userName);
    }
}
