using BookClubApp.Models;


namespace BookClubApp.Services
{
    /// <summary>
    /// IBookService interface
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Find all books
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>List of BookModel</returns>
        IList<BookModel> GetAllBooks(string userName);

        /// <summary>
        /// Find readed book for User
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>List of BookModel</returns>
        IList<BookModel> GetReadedBooks(string userName);

        /// <summary>
        /// Add book to readed list
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="userName">username</param>
        void AddToReadedBook(int bookId, string userName);

        /// <summary>
        /// Delete book from readed list
        /// </summary>
        /// <param name="bookId">book Id</param>
        /// <param name="userName">username</param>
        void DeleteFromReadedBook(int bookId, string userName);
    }
}
