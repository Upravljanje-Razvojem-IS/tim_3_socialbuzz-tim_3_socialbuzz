using AutoMapper;
using PictureService.CustomException;
using PictureService.Data;
using PictureService.DTOs.PostPictureDTOs;
using PictureService.Entities;
using PictureService.Interfaces;
using PictureService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Repository
{
    public class PostPictureRepository : IPostPictureRepository
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;


        public PostPictureRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public PostPictureConfirmationDto Create(PostPictureCreateDto dto)
        {
            PostPicture postPicture = new PostPicture()
            {
                
                PictureType = dto.PictureType,
                Url = dto.Url,
                PostId = dto.PostId
            };


            _context.PostPictures.Add(postPicture);
            _context.SaveChanges();
            _logger.Log("Created postPicture!");
            return _mapper.Map<PostPictureConfirmationDto>(postPicture);
        }

        public void Delete(Guid id)
        {
            var postPicture = _context.PostPictures.FirstOrDefault(e => e.Id == id);
            if (postPicture == null)
                throw new BusinessException("PostPicture doesnt exist");
            _context.Remove(postPicture);
            _logger.Log("PostPicture deleted");
            _context.SaveChanges();
        }

        public List<PostPictureReadDto> Get()
        {
            var list = _context.PostPictures.ToList();
            _logger.Log("Get all postPictures!");
            return _mapper.Map<List<PostPictureReadDto>>(list);
        }

        public PostPictureReadDto Get(Guid id)
        {
            var entity = _context.PostPictures.FirstOrDefault(e => e.Id == id);
            _logger.Log("Get postPicture by id");
            return _mapper.Map<PostPictureReadDto>(entity);
        }

        public PostPictureConfirmationDto Update(Guid id, PostPictureCreateDto dto)
        {
            var postPictures = _context.PostPictures.FirstOrDefault(e => e.Id == id);
            if (postPictures == null)
                throw new BusinessException("PostPicture doesnt exist");
            postPictures.Url = dto.Url;
            postPictures.PostId = dto.PostId;

            _context.SaveChanges();
            _logger.Log("PostPicture updated");
            return _mapper.Map<PostPictureConfirmationDto>(postPictures);
        }
    }
}
