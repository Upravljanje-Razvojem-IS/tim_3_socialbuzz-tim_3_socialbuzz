using AutoMapper;
using PostService.Data;
using PostService.DTOs.ProductDTOs;
using PostService.Entities;
using PostService.Interface;
using PostService.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContet _db;
        private readonly IMapper _mapper;

        public ProductRepository(DatabaseContet db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ProductConfirmationDTO Create(ProductCreateDTO dto)
        {
            var owner = MockData.owners.FirstOrDefault(e => e.Id == dto.OwnerId);
            var price = MockData.prices.FirstOrDefault(e => e.Id == dto.PriceId);

            if (owner == null || price == null)
                throw new NullReferenceException();


            Product newProduct = new Product()
            {
                Id = Guid.NewGuid(),
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                Dangerious = dto.Dangerious,
                Date = dto.Date,
                Description = dto.Description,
                Fragile = dto.Fragile,
                PostPictureId = dto.PostPictureId,
                Quantity = dto.Quantity,
                Title = dto.Title,
                Weight = dto.Weight,
                PriceId = dto.PriceId,
                OwnerId = dto.OwnerId
            };

            _db.Products.Add(newProduct);
            _db.SaveChanges();

            return _mapper.Map<ProductConfirmationDTO>(newProduct);
        }

        public List<ProductReadDTO> Get()
        {
            var list = _db.Products.ToList();

            return _mapper.Map<List<ProductReadDTO>>(list);
        }

        public ProductReadDTO Get(Guid id)
        {
            var entity = _db.Products.FirstOrDefault(e => e.Id == id);

            return _mapper.Map<ProductReadDTO>(entity);
        }

        public ProductConfirmationDTO Update(Guid id, ProductCreateDTO dto)
        {
            var entity = _db.Products.FirstOrDefault(e => e.Id == id);
            if(entity == null)
                throw new NullReferenceException();

            var owner = MockData.owners.FirstOrDefault(e => e.Id == dto.OwnerId);
            var price = MockData.prices.FirstOrDefault(e => e.Id == dto.PriceId);

            if (owner == null || price == null)
                throw new NullReferenceException();

            entity.Fragile = dto.Fragile;
            entity.Date = dto.Date;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.City = dto.City;
            entity.Country = dto.Country;
            entity.Address = dto.Address;
            entity.PostPictureId = dto.PostPictureId;
            entity.OwnerId = dto.OwnerId;
            entity.PriceId = dto.PriceId;
            entity.Weight = dto.Weight;
            entity.Quantity = dto.Quantity;
            entity.Dangerious = dto.Dangerious;

            _db.SaveChanges();

            return _mapper.Map<ProductConfirmationDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _db.Products.FirstOrDefault(e => e.Id == id);

            if (entity != null)
            {
                _db.Products.Remove(entity);
                _db.SaveChanges();
            }
        }

    }
}
