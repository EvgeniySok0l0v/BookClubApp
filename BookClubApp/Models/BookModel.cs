namespace BookClubApp.Models
{
    /// <summary>
    /// BookModel
    /// </summary>
    /// <param name="id">book Id</param>
    /// <param name="title">book title</param>
    /// <param name="isReaded">bool val</param>
    public class BookModel(int id, string? title, bool isReaded)
    {
        public int Id { get; set; } = id;
        public string? Title { get; set; } = title;
        public bool IsReaded { get; set; } = isReaded;
    }
}
