using PostService.DTOs.PictureDTO;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IPostPictureRepository
    {
        List<PictureReadDto> Get();
        PictureReadDto Get(Guid id);
        PictureConfirmationDto Create(PictureCreateDto dto);
        PictureConfirmationDto Update(Guid id, PictureCreateDto dto);
        void Delete(Guid id);
    }
}
