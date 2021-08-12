using PostService.DTOs.PictureDTO;
using System;
using System.Collections.Generic;

namespace PostService.Interface
{
    public interface IPostPictureRepository
    {
        List<PictureReadDTO> Get();
        PictureReadDTO Get(Guid id);
        PictureConfirmationDTO Create(PictureCreateDTO dto);
        PictureConfirmationDTO Update(Guid id, PictureCreateDTO dto);
        void Delete(Guid id);
    }
}
