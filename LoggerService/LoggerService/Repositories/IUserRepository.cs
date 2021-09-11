using LoggerService.Model;
using System;

namespace LoggerService.Repositories
{
    public interface IUserRepository
    {
        public User GetById(Guid id);
        public User SaveUser(User user);
        public User UpdateUser(User user);
    }
}
