using AutoMapper;
using PriceService.Data;
using PriceService.DTOs;
using PriceService.Entities;
using PriceService.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceService.Repository
{
    public class PriceHistoryRepository : IPriceHistoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public PriceHistoryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PriceHistoryConfirmationDto Create(PriceHistoryCreateDto dto)
        {
            PriceHistory newHistory = new PriceHistory()
            {
                Id = Guid.NewGuid(),
                Amount = dto.Amount,
                Currency = dto.Currency,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                PriceId = dto.PriceId
            };

            _context.PriceHistories.Add(newHistory);
            _context.SaveChanges();

            return _mapper.Map<PriceHistoryConfirmationDto>(newHistory);
        }

        public void Delete(Guid id)
        {
            var history = _context.PriceHistories.FirstOrDefault(e => e.Id == id);

            if (history != null)
            {
                _context.PriceHistories.Remove(history);
                _context.SaveChanges();
            }
        }

        public List<PriceHistoryReadDto> Get()
        {
            var histories = _context.PriceHistories.ToList();

            return _mapper.Map<List<PriceHistoryReadDto>>(histories);
        }

        public PriceHistoryReadDto Get(Guid id)
        {
            var history = _context.PriceHistories.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<PriceHistoryReadDto>(history);
        }

        public PriceHistoryConfirmationDto Update(Guid id, PriceHistoryCreateDto dto)
        {
            var history = _context.PriceHistories.FirstOrDefault(e => e.Id == id);

            if (history == null)
                return null;

            history.Amount = dto.Amount;
            history.Currency = dto.Currency;
            history.DateFrom = dto.DateFrom;
            history.DateTo = dto.DateTo;
            history.PriceId = dto.PriceId;

            _context.SaveChanges();

            return _mapper.Map<PriceHistoryConfirmationDto>(history);
        }
    }
}
