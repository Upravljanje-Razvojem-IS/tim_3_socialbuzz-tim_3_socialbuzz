using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeliveryService.API.CustomException;
using DeliveryService.API.Interfaces;
using DeliveryService.API.MockedLogger;
using DeliveryService.API.Models.PriceDistanceModels;
using DeliveryService.API.Entities;
using DeliveryService.API.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryService.API.Services
{
    public class PriceDistanceService : IPriceDistance
    {
        private readonly DeliveryServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFakeLogger _logger;

        public PriceDistanceService(DeliveryServiceDbContext context, IMapper mapper, IFakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<PriceDistanceOverview>> BrowseAsync()
        {
            var distances = await _context.PriceDistances
                .ProjectTo<PriceDistanceOverview>(_mapper.ConfigurationProvider)
                .ToListAsync();
            _logger.Log("PriceDistance BrowseAsync() executed!");

            return await Task.FromResult(distances);
        }

        public async Task<PriceDistanceDetails> FindAsync(Guid id)
        {
            var distanceById = await _context.PriceDistances
                .ProjectTo<PriceDistanceDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
            _logger.Log("PriceDistance FindAsync() executed!");

            if (distanceById == null)
                throw new DeliveryException("Sorry, this PriceDistance does not exists", 404);

            return await Task.FromResult(distanceById);
        }

        public async Task<PriceDistanceConfirmation> CreateAsync(PriceDistancePostBody priceDistance)
        {
            PriceDistance newDistance = new()
            {
                Id = Guid.NewGuid(),
                MinimalDistance = priceDistance.MinimalDistance,
                MaximalDistance = priceDistance.MaximalDistance,
                Price = priceDistance.Price
            };
            await _context.PriceDistances.AddAsync(newDistance);
            await _context.SaveChangesAsync();
            _logger.Log("PriceDistance CreateAsync() executed!");

            return await Task.FromResult(_mapper.Map<PriceDistanceConfirmation>(newDistance));
        }

        public async Task<PriceDistanceConfirmation> UpdateAsync(Guid id, PriceDistancePutBody priceDistance)
        {
            var updateDistance = await _context.PriceDistances.FirstOrDefaultAsync(e => e.Id == id);

            if (updateDistance == null)
                throw new DeliveryException("Sorry, this PriceDistance does not exist");

            updateDistance.MinimalDistance = priceDistance.MinimalDistance;
            updateDistance.MaximalDistance = priceDistance.MaximalDistance;
            updateDistance.Price = priceDistance.Price;
            await _context.SaveChangesAsync();
            _logger.Log("PriceDistance UpdateAsync() executed!");

            return await Task.FromResult(_mapper.Map<PriceDistanceConfirmation>(updateDistance));
        }

        public async Task DeleteAsync(Guid id)
        {
            var deleteDistance = await _context.PriceDistances
                .FirstOrDefaultAsync(e => e.Id == id);

            if (deleteDistance == null)
                throw new DeliveryException("Sorry, this PriceDistance does not exist", 400);

            _context.PriceDistances.Remove(deleteDistance);
            await _context.SaveChangesAsync();
            _logger.Log("PriceDistance DeleteAsync() executed!");
            _logger.Log("Sorry, this PriceDistance with given ID does not exist");
        }
    }
}
