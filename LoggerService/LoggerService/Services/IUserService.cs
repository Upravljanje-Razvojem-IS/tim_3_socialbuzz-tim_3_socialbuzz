using LoggerService.Dtos;
using System;

namespace LoggerService.Services
{
    public interface IUserService
    {
        public UserDto SaveUser(SaveUserDto userDto);
        public UserDto UpdateUser(Guid id, UpdateUserDto userDto);
    }
}
