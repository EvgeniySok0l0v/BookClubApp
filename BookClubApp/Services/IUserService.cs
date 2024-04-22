using BookClubApp.Entity;

namespace BookClubApp.Services
{
    /// <summary>
    /// IUserService interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Find user by username
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>User</returns>
        User GetUserByUserName(string userName);

        /// <summary>
        /// Get user id by username
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns>id of user</returns>
        int GetUserIdByUserName(string userName);

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="user">User</param>
        void CreateUser(User user);
    }
}
