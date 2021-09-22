using AutoMapper;
using LoggerService.Dtos;
using LoggerService.Exceptions;
using LoggerService.Model;
using LoggerService.Repositories;
using System;

namespace LoggerService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public UserDto SaveUser(SaveUserDto userDto)
        {
            var user = _userRepo.GetById(userDto.Id);

            if (user != null)
            {
                throw new UserExistsException(userDto.Id);
            }

            return _mapper.Map<UserDto>(_userRepo.SaveUser(_mapper.Map<User>(userDto)));
        }

        public UserDto UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var user = _userRepo.GetById(id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Id = id;

            return _mapper.Map<UserDto>(_userRepo.UpdateUser(user));
        }
    }
}
