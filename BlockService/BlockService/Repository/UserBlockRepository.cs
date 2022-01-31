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
    public class UserBlockRepository : IUserBlockRepository
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public UserBlockRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public UserBlockConfirmationDto Create(UserBlockCreateDto dto)
        {
            UserBlock kreiranUserBlock = new UserBlock()
            {
                Id = Guid.NewGuid(),
                BlockerId = dto.BlockerId,
                BlockedId = dto.BlockedId

            };

            _context.UserBlocks.Add(kreiranUserBlock);

            _context.SaveChanges();

            _logger.Log("Create UserBlock!");

            return _mapper.Map<UserBlockConfirmationDto>(kreiranUserBlock);
        }

        public void Delete(Guid id)
        {
            var UserBlock = _context.UserBlocks.FirstOrDefault(e => e.Id == id);

            if (UserBlock == null)
                throw new BusinessException("UserWatch does not exist");

            _context.UserBlocks.Remove(UserBlock);

            _logger.Log("UserBlock deleted!");

            _context.SaveChanges();
        }

        public List<UserBlockReadDto> Get()
        {
            var list = _context.UserBlocks.ToList();

            _logger.Log("Get all UserBlocks!");

            return _mapper.Map<List<UserBlockReadDto>>(list);
        }

        public UserBlockReadDto Get(Guid id)
        {
            var entity = _context.UserBlocks.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get UserBlocks by Id!");

            return _mapper.Map<UserBlockReadDto>(entity);
        }

        public UserBlockConfirmationDto Update(Guid id, UserBlockCreateDto dto)
        {
            var UserBlock = _context.UserBlocks.FirstOrDefault(e => e.Id == id);

            if (UserBlock == null)
                throw new BusinessException("UserBlock does not exist");

            UserBlock.BlockerId = dto.BlockerId;
            UserBlock.BlockedId = dto.BlockedId;

            _context.SaveChanges();

            _logger.Log("UserBlock updated!!");

            return _mapper.Map<UserBlockConfirmationDto>(UserBlock);
        }
    }
}
