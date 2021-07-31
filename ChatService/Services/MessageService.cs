using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatService.CustomException;
using ChatService.Database;
using ChatService.DTOs.MessageDTOs;
using ChatService.Entities;
using ChatService.Interfaces;
using ChatService.MockData;
using Logistics.API.MockLogger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatService.Services
{
    public class MessageService : IMessageService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly FakeLogger _logger;


        public MessageService(DatabaseContext context, IMapper mapper, FakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public MessageConfirmationDTO Create(MessageCreateDTO dto)
        {
            var users = UserData.GetUsers();

            var user = users.FirstOrDefault(e => e.Id == dto.OwnerId);

            if (user == null)
                throw new BussinessException("User does not exist", 400);

            Message newEntity = new Message()
            {
                Id = Guid.NewGuid(),
                Body = dto.Body,
                IsDeleted = dto.IsDeleted,
                ChatId = dto.ChatId,
                OwnerId = dto.OwnerId,
                MessageTypeId = dto.MessageTypeId,
            };

            _context.Add(newEntity);
            _context.SaveChanges();

            _logger.Log("Create Message");

            return _mapper.Map<MessageConfirmationDTO>(newEntity);
        }

        public List<MessageReadDTO> Get()
        {
            var entities = _context.Messages
                .ProjectTo<MessageReadDTO>(_mapper.ConfigurationProvider)
                .ToList();

            _logger.Log("Get Messages");

            return entities;
        }

        public MessageReadDTO Get(Guid id)
        {
            var entity = _context.Messages
                .ProjectTo<MessageReadDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefault(e => e.Id == id);

            _logger.Log("Get Message");

            return entity;
        }

        public MessageConfirmationDTO Update(Guid id, MessageCreateDTO dto)
        {
            var users = UserData.GetUsers();

            var user = users.FirstOrDefault(e => e.Id == dto.OwnerId);

            if (user == null)
                throw new BussinessException("User does not exist", 400);

            var entity = _context.Messages.FirstOrDefault(e => e.Id == id);

            entity.IsDeleted = dto.IsDeleted;
            entity.Body = dto.Body;
            entity.ChatId = dto.ChatId;
            entity.MessageTypeId = dto.MessageTypeId;
            entity.OwnerId = dto.OwnerId;

            _context.SaveChanges();

            _logger.Log("Update Message");

            return _mapper.Map<MessageConfirmationDTO>(entity);
        }


        public void Delete(Guid id)
        {
            var entity = _context.Messages.FirstOrDefault(e => e.Id == id);

            if(entity == null)
                throw new BussinessException("Message does not exist");

            _context.Remove(entity);
            _context.SaveChanges();

            _logger.Log("Delete Message");
        }

    }
}
