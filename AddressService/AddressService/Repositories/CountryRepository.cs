using AddressService.Database;
using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressService.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AddressServiceDatabase _context;

        public CountryRepository(AddressServiceDatabase context)
        {
            _context = context;
        }
        public Country GetById(Guid id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IList<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }
    }
}
