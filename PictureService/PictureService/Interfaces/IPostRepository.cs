using PictureService.DTOs.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Interfaces
{
   public interface IPostRepository
    {
        List<PostReadDto> Get();
        PostReadDto Get(Guid id);
        PostConfirmationDto Create(PostCreateDto dto);
        PostConfirmationDto Update(Guid id, PostCreateDto dto);
        void Delete(Guid id);
    }
}
