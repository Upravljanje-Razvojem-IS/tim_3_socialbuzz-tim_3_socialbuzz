using AutoMapper;
using PictureService.CustomException;
using PictureService.Data;
using PictureService.DTOs.OwnerDTOs;
using PictureService.Entities;
using PictureService.Interfaces;
using PictureService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Repository
{
    public class OwnerRepository : IOwnerRepository
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;


        public OwnerRepository(MockLogger logger,IMapper mapper,DatabaseContext context)
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
                UserName = dto.UserName,
                Email = dto.Email
            };
            _context.Owners.Add(created);
            _context.SaveChanges();
            _logger.Log("Create owner!");
            return _mapper.Map<OwnerConfirmationDto>(created);
        }

        public void Delete(Guid id)
        {
          var owner = _context.Owners.FirstOrDefault(e => e.Id == id);
            if (owner == null)
                throw new BusinessException("Owner doesnt exist");
            _context.Owners.Remove(owner);
            _logger.Log("Owner deleted");
            _context.SaveChanges();
        }

        public List<OwnerReadDto> Get()
        {
            var list = _context.Owners.ToList();
            _logger.Log("Get all owners!");
            return _mapper.Map<List<OwnerReadDto>>(list);
        }
       
        public OwnerReadDto Get(Guid id)
        {
            var entity = _context.Owners.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get owner by id");
            return _mapper.Map<OwnerReadDto>(entity);
        }  

        public OwnerConfirmationDto Update(Guid id, OwnerCreateDto dto)
        {
            var owner = _context.Owners.FirstOrDefault(e => e.Id == id);
            if (owner == null)
                throw new BusinessException("Owner doesnt exist");

            owner.UserName = dto.UserName;
            owner.Email = dto.Email;
            _context.SaveChanges();
            _logger.Log("Owner updated");
            return _mapper.Map<OwnerConfirmationDto>(owner);
        }
    }
}
