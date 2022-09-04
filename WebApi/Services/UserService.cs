using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUser(User u)
        {
            try
            {
                _dbContext.Users.Add(u);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            return user;

        }

        public User UpdateUser(User u)
        {
            User user = _dbContext.Users.Where(item=>item.Id == u.Id).FirstOrDefault();
            user.Email = u.Email;
            user.Name = u.Name;
            user.Password = u.Password;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }

        public bool DeleteUserById(int id)
        {
            try
            {
                User user = GetUserById(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
