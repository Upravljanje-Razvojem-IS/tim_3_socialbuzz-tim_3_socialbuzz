using AutoMapper;
using CommentService.CustomException;
using CommentService.Data;
using CommentService.DTOs.CommentDTOs;
using CommentService.Entities;
using CommentService.Interfaces;
using CommentService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommentService.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;

        public CommentRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public CommentConfirmationDto Create(CommentCreateDto dto)
        {
            Comment created = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = dto.Content,
                CreatedAt = dto.CreatedAt,
                PosId = dto.PostId,
                UserId = dto.UserId
            };

            _context.Comments.Add(created);

            _context.SaveChanges();

            _logger.Log("Create Comment!");

            return _mapper.Map<CommentConfirmationDto>(created);
        }

        public List<CommentReadDto> Get()
        {
            var list = _context.Comments.ToList();

            _logger.Log("Get all Comments!");

            return _mapper.Map<List<CommentReadDto>>(list);
        }

        public CommentReadDto Get(Guid id)
        {
            var entity = _context.Comments.FirstOrDefault(e => e.Id == id);

            _logger.Log("Get Comment by id");

            return _mapper.Map<CommentReadDto>(entity);
        }

        public CommentConfirmationDto Update(Guid id, CommentCreateDto dto)
        {
            var comment = _context.Comments.FirstOrDefault(e => e.Id == id);

            if (comment == null)
                throw new BusinessException("Comment doesnt exist");

            comment.Content = dto.Content;
            comment.CreatedAt = dto.CreatedAt;
            comment.PosId = dto.PostId;
            comment.UserId = dto.UserId;

            _context.SaveChanges();

            _logger.Log("Comment updated!");

            return _mapper.Map<CommentConfirmationDto>(comment);
        }

        public void Delete(Guid id)
        {
            var comment = _context.Comments.FirstOrDefault(e => e.Id == id);

            if (comment == null)
                throw new BusinessException("Comment doesnt exist");

            _context.Comments.Remove(comment);

            _logger.Log("Comment deleted!");

            _context.SaveChanges();
        }
    }
}
