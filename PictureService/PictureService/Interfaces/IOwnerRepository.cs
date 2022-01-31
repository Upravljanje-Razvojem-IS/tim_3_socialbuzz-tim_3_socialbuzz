using PictureService.DTOs.OwnerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Interfaces
{
   public interface IOwnerRepository
    {
        List<OwnerReadDto> Get();
        OwnerReadDto Get(Guid id);
        OwnerConfirmationDto Create(OwnerCreateDto dto);
        OwnerConfirmationDto Update(Guid id, OwnerCreateDto dto);
        void Delete(Guid id);
    }
}
