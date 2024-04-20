using BookClubApp.Entity;
using BookClubApp.Models;

namespace BookClubApp.Mappers
{
    public class BookMapper
    {
        public static BookModel BookToBookModel(Book book, bool isReaded) => new(book.Id, book.Title, isReaded);
    }
}
