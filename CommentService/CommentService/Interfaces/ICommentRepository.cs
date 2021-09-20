using CommentService.DTOs.CommentDTOs;
using System;
using System.Collections.Generic;

namespace CommentService.Interfaces
{
    public interface ICommentRepository
    {
        List<CommentReadDto> Get();
        CommentReadDto Get(Guid id);
        CommentConfirmationDto Create(CommentCreateDto dto);
        CommentConfirmationDto Update(Guid id, CommentCreateDto dto);
        void Delete(Guid id);
    }
}
