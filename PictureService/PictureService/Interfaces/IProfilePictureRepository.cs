using PictureService.DTOs.ProfilePictureDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Interfaces
{
   public interface IProfilePictureRepository
    {
        List<ProfilePictureReadDto> Get();
        ProfilePictureReadDto Get(Guid id);

        ProfilePictureConfirmationDto Create(ProfilePictureCreateDto dto);
        ProfilePictureConfirmationDto Update(Guid id, ProfilePictureCreateDto dto);
        void Delete(Guid id);
    }
}
