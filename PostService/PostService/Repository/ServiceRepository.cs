using AutoMapper;
using PostService.Data;
using PostService.DTOs.ServiceDTOs;
using PostService.Entities;
using PostService.Interface;
using PostService.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostService.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DatabaseContet _db;
        private readonly IMapper _mapper;

        public ServiceRepository(IMapper mapper, DatabaseContet db)
        {
            _mapper = mapper;
            _db = db;
        }

        public ServiceConfirmationDto Create(ServiceCreateDto dto)
        {
            var owner = MockData.owners.FirstOrDefault(e => e.Id == dto.OwnerId);
            var price = MockData.prices.FirstOrDefault(e => e.Id == dto.PriceId);

            if (owner == null || price == null)
                throw new NullReferenceException();


            Service newService = new Service()
            {
                Id = Guid.NewGuid(),
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                Date = dto.Date,
                Description = dto.Description,
                PostPictureId = dto.PostPictureId,
                Title = dto.Title,
                PriceId = dto.PriceId,
                OwnerId = dto.OwnerId,
                Durotation = dto.Durotation
            };

            _db.Services.Add(newService);
            _db.SaveChanges();

            return _mapper.Map<ServiceConfirmationDto>(newService);
        }

        public void Delete(Guid id)
        {
            var entity = _db.Services.FirstOrDefault(e => e.Id == id);

            if (entity != null)
            {
                _db.Services.Remove(entity);
                _db.SaveChanges();
            }
        }

        public List<ServiceReadDto> Get()
        {
            var list = _db.Services.ToList();

            return _mapper.Map<List<ServiceReadDto>>(list);
        }

        public ServiceReadDto Get(Guid id)
        {
            var entity = _db.Services.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<ServiceReadDto>(entity);
        }

        public ServiceConfirmationDto Update(Guid id, ServiceCreateDto dto)
        {
            var entity = _db.Services.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new NullReferenceException();

            var owner = MockData.owners.FirstOrDefault(e => e.Id == dto.OwnerId);
            var price = MockData.prices.FirstOrDefault(e => e.Id == dto.PriceId);

            if (owner == null || price == null)
                throw new NullReferenceException();

            entity.Date = dto.Date;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.Address = dto.Address;
            entity.PostPictureId = dto.PostPictureId;
            entity.OwnerId = dto.OwnerId;
            entity.PriceId = dto.PriceId;
            entity.Durotation = dto.Durotation;

            _db.SaveChanges();

            return _mapper.Map<ServiceConfirmationDto>(entity);
        }
    }
}
