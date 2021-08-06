using AutoMapper;
using PostService.Data;
using PostService.DTOs.PictureDTO;
using PostService.Entities;
using PostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostService.Repository
{
    public class PostPictureRepository : IPostPictureRepository
    {
        private readonly DatabaseContet _db;
        private readonly IMapper _mapper;

        public PostPictureRepository(IMapper mapper, DatabaseContet db)
        {
            _mapper = mapper;
            _db = db;
        }

        public PictureConfirmationDTO Create(PictureCreateDTO dto)
        {
            PostPicture newEntity = new PostPicture()
            {
                Id = Guid.NewGuid(),
                Url = dto.Url
            };

            _db.Pictures.Add(newEntity);
            _db.SaveChanges();

            return _mapper.Map<PictureConfirmationDTO>(newEntity);
        }

        public List<PictureReadDTO> Get()
        {
            var list = _db.Pictures.ToList();

            return _mapper.Map<List<PictureReadDTO>>(list);
        }

        public PictureReadDTO Get(Guid id)
        {
            var entity = _db.Pictures.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<PictureReadDTO>(entity);
        }

        public PictureConfirmationDTO Update(Guid id, PictureCreateDTO dto)
        {
            var entityToUpdate = _db.Pictures.FirstOrDefault(e => e.Id == id);

            if (entityToUpdate == null)
                throw new NullReferenceException();

            entityToUpdate.Url = dto.Url;

            _db.SaveChanges();

            return _mapper.Map<PictureConfirmationDTO>(entityToUpdate);
        }

        public void Delete(Guid id)
        {
            var entity = _db.Pictures.FirstOrDefault(e => e.Id == id);

            if (entity != null)
            {
                _db.Pictures.Remove(entity);
                _db.SaveChanges();
            }
        }

    }
}
