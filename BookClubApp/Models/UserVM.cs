namespace BookClubApp.Models
{
    public class UserVM
    {
        private long _id;
        private string _userName;

        public UserVM() { }

        public UserVM(long id, string userName) 
        {
            _id = id;
            _userName = userName;
        }
        public long Id { get { return _id; } }
        public string UserName { get { return _userName;} }

    }
}
