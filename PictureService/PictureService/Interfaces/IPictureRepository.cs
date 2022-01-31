using PictureService.DTO.PictureDTOs;
using PictureService.DTOs.PictureDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Interfaces
{
  public  interface IPictureRepository
    {
        List<PictureReadDto> Get();
        PictureReadDto Get(Guid id);
        PictureConfirmationDto Create(PictureCreateDto dto);
        PictureConfirmationDto Update(Guid id, PictureCreateDto dto);
        void Delete(Guid id);

    }
}
