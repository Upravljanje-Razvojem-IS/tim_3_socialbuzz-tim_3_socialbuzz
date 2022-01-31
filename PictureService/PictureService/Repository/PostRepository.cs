﻿using AutoMapper;
using PictureService.CustomException;
using PictureService.Data;
using PictureService.DTOs.PictureDTOs;
using PictureService.DTOs.PostDTOs;
using PictureService.Entities;
using PictureService.Interfaces;
using PictureService.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly MockLogger _logger;


        public PostRepository(MockLogger logger, IMapper mapper, DatabaseContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public PostConfirmationDto Create(PostCreateDto dto)
        {
            Post created = new Post()
            {
                Id = Guid.NewGuid(),
                Title = dto.Title
            };

            _context.Posts.Add(created);
            _context.SaveChanges();
            _logger.Log("Create post!");
            return _mapper.Map<PostConfirmationDto>(created);
        }

        public void Delete(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(e => e.Id == id);
            if(post ==null)
                throw new BusinessException("Post doesnt exist");
            _context.Remove(post);
            _logger.Log("Post deleted");
            _context.SaveChanges();
        }

        public List<PostReadDto> Get()
        {
            var list = _context.Posts.ToList();
            _logger.Log("Get all posts!");
            return _mapper.Map<List<PostReadDto>>(list);
        }

        public PostReadDto Get(Guid id)
        {
            var entity = _context.Posts.FirstOrDefault(e => e.Id == id);
            _logger.Log("Get post by id");
            return _mapper.Map<PostReadDto>(entity);
        }

        public PostConfirmationDto Update(Guid id, PostCreateDto dto)
        {
            var post = _context.Posts.FirstOrDefault(e => e.Id == id);
            if (post == null)
                throw new BusinessException("Post doesnt exist");
            post.Title = dto.Title;
            _context.SaveChanges();
            _logger.Log("Post updated");
            return _mapper.Map<PostConfirmationDto>(post);
        }
    }
}
