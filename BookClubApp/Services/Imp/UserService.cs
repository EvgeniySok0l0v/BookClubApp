using BookClubApp.Entity;


namespace BookClubApp.Services.Imp
{
    public class UserService(ApplicationDbContext context) : IUserService
    {
        private readonly ApplicationDbContext _context = context;
        public User GetUserByUserName(string userName) => _context.Users.First(u => u.UserName == userName);

        public int GetUserIdByUserName(string userName) => _context.Users.First(u => u.UserName == userName).Id;
    }
}
