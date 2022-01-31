using AutoMapper;
using PictureService.CustomException;
using PictureService.Data;
using PictureService.DTO.PictureDTOs;
using PictureService.DTOs.PictureDTOs;
using PictureService.Entities;
using PictureService.Interfaces;
using PictureService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Repository
{
    public class PictureRepository : IPictureRepository
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;


        public PictureRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public PictureConfirmationDto Create(PictureCreateDto dto)
        {
            Picture created = new Picture()
            {
                Id = Guid.NewGuid(),
                Url = dto.Url

            };
            _context.Pictures.Add(created);
            _context.SaveChanges();
            _logger.Log("Create picture");
            return _mapper.Map<PictureConfirmationDto>(created);

        }

        public void Delete(Guid id)
        {
            var picture = _context.Pictures.FirstOrDefault(e => e.Id == id);
            if(picture == null)
                throw new BusinessException("Picture doesnt exist");
            _context.Pictures.Remove(picture);
            _logger.Log("Picture deleted");
            _context.SaveChanges();
        }

        public List<PictureReadDto> Get()
        {
            var list = _context.Pictures.ToList(); ;
            _logger.Log("Get all pictures!");
            return _mapper.Map<List<PictureReadDto>>(list);
        }

        public PictureReadDto Get(Guid id)
        {
            var entity = _context.Pictures.FirstOrDefault(e => e.Id == id);
            _logger.Log("Get picture by id");
            return _mapper.Map<PictureReadDto>(entity);
        }

        public PictureConfirmationDto Update(Guid id, PictureCreateDto dto)
        {
            var picture = _context.Pictures.FirstOrDefault(e => e.Id == id);
            if(picture ==null)
                throw new BusinessException("Picture doesnt exist");

            picture.Url = dto.Url;
            _context.SaveChanges();
            _logger.Log("Picture updated");
            return _mapper.Map<PictureConfirmationDto>(picture);
        }
    }
}
