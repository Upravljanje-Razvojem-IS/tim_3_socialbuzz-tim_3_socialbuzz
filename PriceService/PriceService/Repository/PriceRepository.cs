﻿using AutoMapper;
using PriceService.Data;
using PriceService.DTOs;
using PriceService.Entities;
using PriceService.Intefaces;
using PriceService.MockData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceService.Repository
{
    public class PriceRepository : IPriceRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PriceRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PriceConfirmationDto Create(PriceCreateDto dto)
        {
            var post = PostData.Posts().FirstOrDefault(e => e.Id == dto.PostId);

            if (post == null)
                throw new NullReferenceException();

            Price newPrice = new Price()
            {
                Id = Guid.NewGuid(),
                Amount = dto.Amount,
                Currency = dto.Currency,
                Date = dto.Date,
                PostId = dto.PostId
            };

            _context.Prices.Add(newPrice);
            _context.SaveChanges();

            return _mapper.Map<PriceConfirmationDto>(newPrice);
        }

        public List<PriceReadDto> Get()
        {
            var prices = _context.Prices.ToList();

            return _mapper.Map<List<PriceReadDto>>(prices);
        }

        public PriceReadDto Get(Guid id)
        {
            var price = _context.Prices.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<PriceReadDto>(price);
        }

        public PriceConfirmationDto Update(Guid id, PriceCreateDto dto)
        {
            var post = PostData.Posts().FirstOrDefault(e => e.Id == dto.PostId);

            if (post == null)
                throw new NullReferenceException();

            var price = _context.Prices.FirstOrDefault(e => e.Id == id);

            if (price == null)
                return null;

            price.Amount = dto.Amount;
            price.Currency = dto.Currency;
            price.Date = dto.Date;
            price.PostId = dto.PostId;

            _context.SaveChanges();

            return _mapper.Map<PriceConfirmationDto>(price);
        }

        public void Delete(Guid id)
        {
            var price = _context.Prices.FirstOrDefault(e => e.Id == id);

            if(price != null)
            {
                _context.Prices.Remove(price);
                _context.SaveChanges();
            }
        }
    }
}
