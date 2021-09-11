using LoggerService.Database;
using LoggerService.Model;
using System;
using System.Linq;

namespace LoggerService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LoggerServiceDatabase _context;

        public UserRepository(LoggerServiceDatabase context)
        {
            _context = context;
        }
        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public User SaveUser(User user)
        {
            user = _context.Add(user).Entity;
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            user = _context.Users.Update(user).Entity;
            _context.SaveChanges();
            return user;
        }
    }
}
