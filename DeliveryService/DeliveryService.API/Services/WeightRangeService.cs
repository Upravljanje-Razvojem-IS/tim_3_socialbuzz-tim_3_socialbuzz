using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeliveryService.API.CustomException;
using DeliveryService.API.Interfaces;
using DeliveryService.API.MockedLogger;
using DeliveryService.API.Models.WeightRangeModels;
using DeliveryService.API.Entities;
using DeliveryService.API.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DeliveryService.API.Services
{
    public class WeightRangeService : IWeightRangeService
    {
        private readonly DeliveryServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFakeLogger _logger;

        public WeightRangeService(DeliveryServiceDbContext context, IMapper mapper, IFakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<WeightRangeOverview>> BrowseAsync()
        {
            var weights = await _context.WeightRanges
                .ProjectTo<WeightRangeOverview>(_mapper.ConfigurationProvider)
                .ToListAsync();
            _logger.Log("WeightRange BrowseAsync() executed!");

            return await Task.FromResult(weights);
        }
        public async Task<WeightRangeDetails> FindAsync(Guid id)
        {
            var weightById = await _context.WeightRanges
                .ProjectTo<WeightRangeDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
            _logger.Log("WeightRange FindAsync() executed!");

            if (weightById == null)
                throw new LogisticException("Sorry, this WeightRange not found", 404);

            return await Task.FromResult(weightById);
        }

        public async Task<WeightRangeConfirmation> CreateAsync(WeightRangePostBody weightRange)
        {
            WeightRange newWeight = new()
            {
                Id = Guid.NewGuid(),
                MinimalWeight = weightRange.MinimalWeight,
                MaximalWeight = weightRange.MaximalWeight,
                PriceCoefficient = weightRange.PriceCoefficient
            };
            await _context.WeightRanges.AddAsync(newWeight);
            await _context.SaveChangesAsync();
            _logger.Log("WeightRange CreateAsync() executed!");

            return await Task.FromResult(_mapper.Map<WeightRangeConfirmation>(newWeight));
        }

        public async Task<WeightRangeConfirmation> UpdateAsync(Guid id, WeightRangePutBody weightRange)
        {
            var updateWeight = await _context.WeightRanges.FirstOrDefaultAsync(e => e.Id == id);

            if (updateWeight == null)
                throw new LogisticException("Sorry, this WeightRange does not exist", 400);
            
            updateWeight.MinimalWeight = weightRange.MinimalWeight;
            updateWeight.MaximalWeight = weightRange.MaximalWeight;
            updateWeight.PriceCoefficient = weightRange.PriceCoefficient;
            await _context.SaveChangesAsync();
            _logger.Log("WeightRange UpdateAsync() executed!");

            return await Task.FromResult(_mapper.Map<WeightRangeConfirmation>(updateWeight));
        }

        public async Task DeleteAsync(Guid id)
        {
            var deleteWeight = await _context.WeightRanges.FirstOrDefaultAsync(e => e.Id == id);

            if (deleteWeight == null)
                throw new LogisticException("Sorry, this WeightRange doesnt exist", 400);

            _context.WeightRanges.Remove(deleteWeight);
            _logger.Log("WeightRange DeleteAsync() executed!");
            await _context.SaveChangesAsync();
            
        }
    }
}
