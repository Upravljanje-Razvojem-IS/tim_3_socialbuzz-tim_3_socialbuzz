using AutoMapper;
using BlockService.CustomException;
using BlockService.Data;
using BlockService.DTOs;
using BlockService.Entities;
using BlockService.Interfaces;
using BlockService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public UserRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public UserConfirmationDto Create(UserCreateDto dto)
        {

            User kreiranUser = new User()
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Password = dto.Password
            };

            _context.Users.Add(kreiranUser);

            _context.SaveChanges();

            _logger.Log("Create User!");

            return _mapper.Map<UserConfirmationDto>(kreiranUser);
        }


        public List<UserReadDto> Get()
        {
            var list = _context.Users.ToList();

            _logger.Log("Get all users!");

            return _mapper.Map<List<UserReadDto>>(list);
        }

        public UserReadDto Get(Guid id)
        {
            var entity = _context.Users.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get User-a by Id!");

            return _mapper.Map<UserReadDto>(entity);
        }


        public UserConfirmationDto Update(Guid id, UserCreateDto dto)
        {
            var User = _context.Users.FirstOrDefault(e => e.Id == id);

            if (User == null)
                throw new BusinessException("User does not exists");

            User.Username = dto.Username;
            User.Password = dto.Password;

            _context.SaveChanges();

            _logger.Log("User upadated!!");

            return _mapper.Map<UserConfirmationDto>(User);
        }


        public void Delete(Guid id)
        {
            var User = _context.Users.FirstOrDefault(e => e.Id == id);

            if (User == null)
                throw new BusinessException("User does not exist");

            _context.Users.Remove(User);

            _logger.Log("User deleted!");

            _context.SaveChanges();
        }


    }
}
