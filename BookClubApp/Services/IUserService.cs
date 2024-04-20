using BookClubApp.Entity;

namespace BookClubApp.Services
{
    public interface IUserService
    {
        User GetUserByUserName(string userName);

        int GetUserIdByUserName(string userName);
    }
}
