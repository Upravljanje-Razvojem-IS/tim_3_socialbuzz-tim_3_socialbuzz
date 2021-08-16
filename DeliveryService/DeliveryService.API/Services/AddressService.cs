using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeliveryService.API.CustomException;
using DeliveryService.API.Interfaces;
using DeliveryService.API.MockedLogger;
using DeliveryService.API.Models.AddressModels;
using DeliveryService.API.Entities;
using DeliveryService.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.API.Database;

namespace DeliveryService.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly DeliveryServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFakeLogger _logger;

        public AddressService(DeliveryServiceDbContext context, IMapper mapper, IFakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<AddressOverview>> BrowseAsync(Guid cityId)
        {
            var addresses = await _context.Addresses
                .ProjectTo<AddressOverview>(_mapper.ConfigurationProvider)
                .Where(e => e.CityId == cityId)
                .ToListAsync();
            _logger.Log("Address - BrowseAsync() executed");

            return await Task.FromResult(addresses);
        }

        public async Task<AddressDetails> FindAsync(Guid cityId, Guid addressId)
        {
            var addressById = await _context.Addresses
                .ProjectTo<AddressDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == addressId);
            _logger.Log("Address - FindAsync() executed");

            return await Task.FromResult(addressById);
        }

        public async Task<AddressConfirmation> CreateAsync(Guid cityId, AddressPostBody address)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(e => e.Id == cityId);

            if (city == null)
                throw new DeliveryException("Sorry, this city does not exist", 400);

            Address newAddress = new()
            {
                Id = Guid.NewGuid(),
                Street = address.Street,
                Number = address.Number,
                CityId = cityId
            };
            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();
            _logger.Log("Address - CreateAsync() executed");

            return await Task.FromResult(_mapper.Map<AddressConfirmation>(newAddress));
        }

        public async Task<AddressConfirmation> UpdateAsync(Guid cityId, Guid addressId, AddressPutBody address)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(e => e.Id == cityId);

            if (city == null)
                throw new DeliveryException("Sorry, this city does not exist", 400);

            var updatedAddress = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == addressId);

            if (updatedAddress == null)
                throw new DeliveryException("Sorry, this Address does not exist", 400);

            updatedAddress.Street = address.Street;
            updatedAddress.Number = address.Number;
            await _context.SaveChangesAsync();
            _logger.Log("Address - UpdateAsync() executed");

            return await Task.FromResult(_mapper.Map<AddressConfirmation>(updatedAddress));
        }

        public async Task DeleteAsync(Guid cityId, Guid addressId)
        {
            var addressToDelete = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == addressId);

            if (addressToDelete == null)
                throw new DeliveryException("Sorry, this Address does not exists", 400);

            _context.Remove(addressToDelete);
            await _context.SaveChangesAsync();
            _logger.Log("Address - DeleteAsync() executed");
        }


    }
}
