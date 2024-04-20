namespace BookClubApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public bool IsReaded { get; set; }

        public BookModel(int id, string? title, bool isReaded)
        {
            Id = id;
            Title = title;
            IsReaded = isReaded;
        }
    }
}
