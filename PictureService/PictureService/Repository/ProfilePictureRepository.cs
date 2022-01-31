using AutoMapper;
using PictureService.CustomException;
using PictureService.Data;
using PictureService.DTOs.ProfilePictureDTOs;
using PictureService.Entities;
using PictureService.Interfaces;
using PictureService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Repository
{
    public class ProfilePictureRepository : IProfilePictureRepository
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public ProfilePictureRepository(DatabaseContext context, IMapper mapper, MockLogger logger)
        {
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }

        public ProfilePictureConfirmationDto Create(ProfilePictureCreateDto dto)
        {
            ProfilePicture profilePicture = new ProfilePicture()
            {
                Url = dto.Url,
                SetAsProfilePicture = dto.SetAsProfilePicture,
                OwnerId =dto.OwnerId
            };

            _context.ProfilePictures.Add(profilePicture);
            _context.SaveChanges();
            _logger.Log("Created ProfilePicture!");
            return _mapper.Map<ProfilePictureConfirmationDto>(profilePicture);
        }

        public void Delete(Guid id)
        {
            var profilePicture = _context.ProfilePictures.FirstOrDefault(e => e.Id == id);
            if (profilePicture == null)
                throw new BusinessException("ProfilePicture doesnt exist");
            _context.Remove(profilePicture);
            _logger.Log("ProfilePicture deleted");
            _context.SaveChanges();
        }

        public List<ProfilePictureReadDto> Get()
        {
            var list = _context.ProfilePictures.ToList();
            _logger.Log("Get all profilePictures!");
            return _mapper.Map<List<ProfilePictureReadDto>>(list);
        }

        public ProfilePictureReadDto Get(Guid id)
        {
            var entity = _context.ProfilePictures.FirstOrDefault(e => e.Id == id);
            _logger.Log("Get profilePicture by id");
            return _mapper.Map<ProfilePictureReadDto>(entity);
        }

        public ProfilePictureConfirmationDto Update(Guid id, ProfilePictureCreateDto dto)
        {
            var profilePictures = _context.ProfilePictures.FirstOrDefault(e => e.Id == id);
            if (profilePictures == null)
                throw new BusinessException("PostPicture doesnt exist");
            profilePictures.Url = dto.Url;
            profilePictures.SetAsProfilePicture = dto.SetAsProfilePicture;
            profilePictures.OwnerId = dto.OwnerId;

            _context.SaveChanges();
            _logger.Log("ProfilePicture updated");
            return _mapper.Map<ProfilePictureConfirmationDto>(profilePictures);
        }
    }
}
