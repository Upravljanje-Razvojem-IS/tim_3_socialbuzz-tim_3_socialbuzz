using PictureService.DTOs.PostPictureDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Interfaces
{
   public  interface IPostPictureRepository
    {
        List<PostPictureReadDto> Get();
        PostPictureReadDto Get(Guid id);
        PostPictureConfirmationDto Create(PostPictureCreateDto dto);
        PostPictureConfirmationDto Update(Guid id, PostPictureCreateDto dto);
        void Delete(Guid id);
    }
}
