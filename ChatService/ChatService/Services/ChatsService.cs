using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatService.CustomException;
using ChatService.Database;
using ChatService.DTOs.ChatDTOs;
using ChatService.Entities;
using ChatService.Interfaces;
using Logistics.API.MockLogger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatService.Services
{
    public class ChatsService : IChatService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly FakeLogger _logger;

        public ChatsService(DatabaseContext context, IMapper mapper, FakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public ChatConfirmationDto Create(ChatCreateDto dto)
        {
            Chat newEntity = new Chat()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Add(newEntity);
            _context.SaveChanges();

            _logger.Log("Create Chat");

            return _mapper.Map<ChatConfirmationDto>(newEntity);
        }

        public List<ChatReadDto> Get()
        {
            var entities = _context.Chats
                .ProjectTo<ChatReadDto>(_mapper.ConfigurationProvider)
                .ToList();

            _logger.Log("Get Chats");

            return entities;
        }

        public ChatReadDto Get(Guid id)
        {
            var entity = _context.Chats
                .ProjectTo<ChatReadDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault(e => e.Id == id);

            _logger.Log("Get Chat");

            return entity;
        }

        public ChatConfirmationDto Update(Guid id, ChatCreateDto dto)
        {
            var entity = _context.Chats
                .FirstOrDefault(e => e.Id == id);

            if (entity == null)
                throw new BussinessException("Chat does not exist", 400);

            entity.Description = dto.Description;
            entity.Name = dto.Name;

            _context.SaveChanges();

            _logger.Log("Update Chat");

            return _mapper.Map<ChatConfirmationDto>(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _context.Chats
                .FirstOrDefault(e => e.Id == id);

            if (entity == null)
                throw new BussinessException("Chat does not exist", 400);

            _context.Remove(entity);
            _context.SaveChanges();

            _logger.Log("Delete Chat");
        }

    }
}
