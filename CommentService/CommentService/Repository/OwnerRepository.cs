using AutoMapper;
using CommentService.CustomException;
using CommentService.Data;
using CommentService.DTOs.OwnerDTOs;
using CommentService.Entities;
using CommentService.Interfaces;
using CommentService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommentService.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public OwnerRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public OwnerConfirmationDto Create(OwnerCreateDto dto)
        {
            Owner created = new Owner()
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Username = dto.Username
            };

            _context.Owners.Add(created);

            _context.SaveChanges();

            _logger.Log("Create Owner!");

            return _mapper.Map<OwnerConfirmationDto>(created);
        }

        public List<OwnerReadDto> Get()
        {
            var list = _context.Owners.ToList();

            _logger.Log("Get all Owners!");

            return _mapper.Map<List<OwnerReadDto>>(list);
        }

        public OwnerReadDto Get(Guid id)
        {
            var entity = _context.Owners.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get Owner by id");

            return _mapper.Map<OwnerReadDto>(entity);
        }

        public OwnerConfirmationDto Update(Guid id, OwnerCreateDto dto)
        {
            var owner = _context.Owners.FirstOrDefault(e => e.Id == id);

            if (owner == null)
                throw new BusinessException("Owner doesnt exist");

            owner.Email = dto.Email;
            owner.Username = dto.Username;

            _context.SaveChanges();

            _logger.Log("Owner updated!");

            return _mapper.Map<OwnerConfirmationDto>(owner);
        }

        public void Delete(Guid id)
        {
            var owner = _context.Owners.FirstOrDefault(e => e.Id == id);

            if (owner == null)
                throw new BusinessException("Owner doesnt exist");

            _context.Owners.Remove(owner);

            _logger.Log("Owner deleted!");

            _context.SaveChanges();
        }
    }
}
