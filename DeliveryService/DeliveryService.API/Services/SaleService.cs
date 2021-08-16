using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeliveryService.API.CustomException;
using DeliveryService.API.Interfaces;
using DeliveryService.API.MockedLogger;
using DeliveryService.API.Models.SaleModels;
using DeliveryService.API.BusinessLogic;
using DeliveryService.API.Entities;
using DeliveryService.API.MockedProduct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryService.API.Database;

namespace DeliveryService.API.Services
{
    public class SaleService : ISaleService
    {
        private readonly DeliveryServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFakeLogger _logger;

        public SaleService(DeliveryServiceDbContext context, IMapper mapper, IFakeLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<SaleOverview>> BrowseAsync()
        {
            var sales = await _context.Sales
                .ProjectTo<SaleOverview>(_mapper.ConfigurationProvider)
                .ToListAsync();
            _logger.Log("Sale BrowseAsync() executed!");
            return await Task.FromResult(sales);
        }

        public async Task<SaleDetails> FindAsync(Guid id)
        {
            var saleById = await _context.Sales
                .ProjectTo<SaleDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == id);
            _logger.Log("Sale BrowseAsync() executed!");

            if (saleById == null)
                throw new DeliveryException("Sorry, this sale not found", 404);

            return await Task.FromResult(saleById);
        }

        public async Task<SaleConfirmation> CreateAsync(SalePostBody sale)
        {
            var fromAddress = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == sale.FromAddressId);
            fromAddress.City = await _context.Cities.FirstOrDefaultAsync(e => e.Id == fromAddress.CityId);
            var toAddress = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == sale.ToAddressId);
            toAddress.City = await _context.Cities.FirstOrDefaultAsync(e => e.Id == toAddress.CityId);

            var product = ProductMockService.ProductMocks.FirstOrDefault(e => e.Id == sale.ProductId);


            Sale newSale = new()
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Pieces = sale.Pieces,
                TotalWeight = 0,
                TotalPriceWithWeightAndDistance = 0,
                FromAddressId = sale.FromAddressId,
                ToAddressId = sale.ToAddressId
            };

            newSale.TotalWeight = product.Weight * newSale.Pieces;
            newSale.WeightRangeId = newSale.WeightRange.Id;
            newSale.Distance = DistanceCalculation.Calculate(fromAddress.City, toAddress.City);
            newSale.PriceDistanceId = newSale.PriceDistance.Id;
            newSale.TotalPriceWithWeightAndDistance = PriceCalculation.Calculate(newSale.Pieces, product.Price, newSale.PriceDistance.Price, newSale.WeightRange.PriceCoefficient);

            await _context.Sales.AddAsync(newSale);
            await _context.SaveChangesAsync();
            _logger.Log("Sale CreateAsync() executed!");

            return await Task.FromResult(_mapper.Map<SaleConfirmation>(newSale));
        }

        public async Task<SaleConfirmation> UpdateAsync(Guid id, SalePutBody sale)
        {
            var p = await _context.Sales.FirstOrDefaultAsync(e => e.Id == id);

            if (p == null)
                throw new DeliveryException("Sorry, this sale does not exist", 400);

            p.ProductId = sale.ProductId;

            var fromAddress = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == sale.FromAddressId);
            p.FromAddess = fromAddress;
            p.FromAddressId = sale.FromAddressId;

            var toAddress = await _context.Addresses.FirstOrDefaultAsync(e => e.Id == sale.ToAddressId);
            p.ToAddress = toAddress;
            p.ToAddressId = sale.ToAddressId;

            p.Pieces = sale.Pieces;

            if (p.Pieces == 0)
                throw new DeliveryException("Number of pieces can not be null", 400);

            var product = ProductMockService.ProductMocks.FirstOrDefault(e => e.Id == sale.ProductId);
            p.TotalWeight = product.Weight * p.Pieces;
            var weightRange = await _context.WeightRanges.FirstOrDefaultAsync(e => e.MinimalWeight < p.TotalWeight && e.MaximalWeight >= p.TotalWeight);
            p.WeightRangeId = weightRange.Id;

            var fromCity = await _context.Cities.FirstOrDefaultAsync(e => e.Id == p.FromAddess.CityId);
            var toCity = await _context.Cities.FirstOrDefaultAsync(e => e.Id == p.ToAddress.CityId);
            p.Distance = DistanceCalculation.Calculate(fromCity, toCity);
            var priceDistance = await _context.PriceDistances.FirstOrDefaultAsync(e => e.MinimalDistance <= p.Distance && e.MaximalDistance > p.Distance);
            p.PriceDistanceId = priceDistance.Id;
            p.TotalPriceWithWeightAndDistance = PriceCalculation.Calculate(p.Pieces, product.Price, priceDistance.Price, weightRange.PriceCoefficient);

            await _context.SaveChangesAsync();
            _logger.Log("Sale UpdateAsync() executed!");

            return await Task.FromResult(_mapper.Map<SaleConfirmation>(p));
        }

        public async Task RemoveAsync(Guid id)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(e => e.Id == id);

            if (sale == null)
                throw new DeliveryException("Sorry, this sale does not exist", 400);

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            _logger.Log("Sale DeleteAsync() executed!");

        }
    }
}
