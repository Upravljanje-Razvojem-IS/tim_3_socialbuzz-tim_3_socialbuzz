using CommentService.DTOs.OwnerDTOs;
using System;
using System.Collections.Generic;

namespace CommentService.Interfaces
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
