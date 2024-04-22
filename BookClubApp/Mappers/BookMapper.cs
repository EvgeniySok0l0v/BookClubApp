using BookClubApp.Entity;
using BookClubApp.Models;

namespace BookClubApp.Mappers
{
    /// <summary>
    /// BookMapper
    /// </summary>
    public class BookMapper
    {
        /// <summary>
        /// Map Book ti BookModel
        /// </summary>
        /// <param name="book">Book</param>
        /// <param name="isReaded">bool val</param>
        /// <returns>BookModel</returns>
        public static BookModel BookToBookModel(Book book, bool isReaded) => new(book.Id, book.Title, isReaded);
    }
}
