using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChatService.CustomException;
using ChatService.Database;
using ChatService.DTOs.MessageTypeDTOs;
using ChatService.Entities;
using ChatService.Interfaces;
using Logistics.API.MockLogger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatService.Services
{
    public class MessageTypeService : IMessageTypeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly FakeLogger _logger;

        public MessageTypeService(DatabaseContext dbContext, IMapper mapper, FakeLogger logger)
        {
            _context = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public MessageTypeConfirmationDTO Create(MessageTypeCreateDTO dto)
        {
            MessageType newEntity = new MessageType()
            {
                Id = Guid.NewGuid(),
                Type = dto.Type
            };

            _context.MessageTypes.Add(newEntity);
            _context.SaveChanges();

            _logger.Log("Create MessageType");

            return _mapper.Map<MessageTypeConfirmationDTO>(newEntity);
        }

        public List<MessageTypeReadDTO> Get()
        {
            var messageTypes = _context.MessageTypes
                .ProjectTo<MessageTypeReadDTO>(_mapper.ConfigurationProvider)
                .ToList();

            _logger.Log("Get MessageTypes");

            return messageTypes;
        }

        public MessageTypeReadDTO Get(Guid id)
        {
            var messageType = _context.MessageTypes
                .ProjectTo<MessageTypeReadDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefault(e => e.Id == id);

            _logger.Log("Get MessageType");

            return messageType;
        }

        public MessageTypeConfirmationDTO Update(Guid id, MessageTypeCreateDTO dto)
        {
            var messageType = _context.MessageTypes.FirstOrDefault(e => e.Id == id);

            if (messageType == null)
                throw new BussinessException("MessageType does not exist", 400);

            messageType.Type = dto.Type;

            _context.SaveChanges();

            _logger.Log("Update MessageType");

            return _mapper.Map<MessageTypeConfirmationDTO>(messageType);
        }


        public void Delete(Guid id)
        {
            var messageType = _context.MessageTypes.FirstOrDefault(e => e.Id == id);

            if (messageType == null)
                throw new BussinessException("MessageType does not exist");

            _context.Remove(messageType);
            _context.SaveChanges();

            _logger.Log("Delete MessageType");
        }
    }
}
