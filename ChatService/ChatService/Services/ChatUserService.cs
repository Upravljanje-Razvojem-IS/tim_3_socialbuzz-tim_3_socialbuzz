using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatService.CustomException;
using ChatService.Database;
using ChatService.DTOs.ChatUser;
using ChatService.Entities;
using ChatService.Interfaces;
using ChatService.MockData;
using Logistics.API.MockLogger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatService.Services
{
    public class ChatUserService : IChatUserService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly FakeLogger _logger;

        public ChatUserService(DatabaseContext context, IMapper mapper, FakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public ChatUserConfirmationDto Create(ChatUserCreateDto dto)
        {
            var users = UserData.GetUsers();

            var user = users.FirstOrDefault(e => e.Id == dto.UserId);

            if (user == null)
                throw new BussinessException("User does not exist", 400);

            ChatUser newEntity = new ChatUser()
            {
                Id = Guid.NewGuid(),
                ChatId = dto.ChatId,
                UserId = dto.UserId
            };

            _context.Add(newEntity);
            _context.SaveChanges();

            _logger.Log("Create ChatUser");

            return _mapper.Map<ChatUserConfirmationDto>(newEntity);
        }

        public List<ChatUserReadDto> Get()
        {
            var entities = _context.ChatUsers
               .ProjectTo<ChatUserReadDto>(_mapper.ConfigurationProvider)
               .ToList();

            _logger.Log("Get ChatUsers");

            return entities;
        }

        public ChatUserReadDto Get(Guid id)
        {
            var entity = _context.ChatUsers
                .ProjectTo<ChatUserReadDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault(e => e.Id == id);

            _logger.Log("Get ChatUser");

            return entity;
        }

        public ChatUserConfirmationDto Update(Guid id, ChatUserCreateDto dto)
        {
            var users = UserData.GetUsers();

            var user = users.FirstOrDefault(e => e.Id == dto.UserId);

            if (user == null)
                throw new BussinessException("User does not exist", 400);

            var entity = _context.ChatUsers.FirstOrDefault(e => e.Id == id);

            entity.UserId = dto.UserId;
            entity.ChatId = dto.ChatId;

            _context.SaveChanges();

            _logger.Log("Update ChatUser");

            return _mapper.Map<ChatUserConfirmationDto>(entity);
        }
        public void Delete(Guid id)
        {
            var entity = _context.ChatUsers.FirstOrDefault(e => e.Id == id);

            if (entity == null)
                throw new BussinessException("ChatUser does not exist");

            _context.Remove(entity);
            _context.SaveChanges();

            _logger.Log("Delete ChatUser");
        }

    }
}
