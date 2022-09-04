using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public User UpdateUser(User user);
        public bool DeleteUserById(int id);
        public bool AddUser(User u);
    }
}
