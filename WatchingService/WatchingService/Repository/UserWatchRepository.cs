using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchingService.CustomException;
using WatchingService.Data;
using WatchingService.DTOs;
using WatchingService.Entities;
using WatchingService.Interfaces;
using WatchingService.Logger;

namespace WatchingService.Repository
{
    public class UserWatchRepository : IUserWatchRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public UserWatchRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public UserWatchConfirmationDto Create(UserWatchCreateDto dto)
        {
            UserWatch kreiranaUserWatch = new UserWatch()
            {
                Id = Guid.NewGuid(),
                WatchedId = dto.WatchedId,
                WatchingId = dto.WatchingId
            };

            _context.UserWatchs.Add(kreiranaUserWatch);

            _context.SaveChanges();

            _logger.Log("Create UserWatch!");

            return _mapper.Map<UserWatchConfirmationDto>(kreiranaUserWatch);
        }

        public List<UserWatchReadDto> Get()
        {
            var list = _context.UserWatchs.ToList();

            _logger.Log("Get all UserWatch!");

            return _mapper.Map<List<UserWatchReadDto>>(list);
        }

        public UserWatchReadDto Get(Guid id)
        {
            var entity = _context.UserWatchs.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get UserWatchs by Id!");

            return _mapper.Map<UserWatchReadDto>(entity);
        }

        public UserWatchConfirmationDto Update(Guid id, UserWatchCreateDto dto)
        {
            var UserWatch = _context.UserWatchs.FirstOrDefault(e => e.Id == id);

            if (UserWatch == null)
                throw new BusinessException("UserWatch does not exist");

            UserWatch.WatchingId = dto.WatchingId;
            UserWatch.WatchedId = dto.WatchedId;

            _context.SaveChanges();

            _logger.Log("UserWatch updated!!");

            return _mapper.Map<UserWatchConfirmationDto>(UserWatch);
        }

        public void Delete(Guid id)
        {
            var UserWatch = _context.UserWatchs.FirstOrDefault(e => e.Id == id);

            if (UserWatch == null)
                throw new BusinessException("UserWatch does not exist");

            _context.UserWatchs.Remove(UserWatch);

            _logger.Log("UserWatch deleted!");

            _context.SaveChanges();
        }
    }
}
