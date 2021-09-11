using AddressService.Database;
using AddressService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressService.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AddressServiceDatabase _context;

        public CityRepository(AddressServiceDatabase context)
        {
            _context = context;
        }
        public void DeleteCity(City city)
        {
            _context.Remove(city);
            _context.SaveChanges();
        }

        public IQueryable<City> GetBasicQuery()
        {
            return _context.Cities.Include(c => c.Country).AsQueryable();
        }

        public City GetById(Guid id)
        {
            return _context.Cities.Include(c => c.Country).FirstOrDefault(c => c.Id.Equals(id));
        }

        public IList<City> GetCitiesForQuery(IQueryable<City> query)
        {
            return query.ToList();
        }

        public City SaveCity(City city)
        {
            city = _context.Add(city).Entity;
            _context.SaveChanges();
            return city;
        }

        public City UpdateCity(City city)
        {
            city = _context.Update(city).Entity;
            _context.SaveChanges();
            return city;
        }
    }
}
