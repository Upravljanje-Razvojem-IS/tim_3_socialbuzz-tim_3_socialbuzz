using AddressService.Models;
using System;
using System.Collections.Generic;

namespace AddressService.Repositories
{
    public interface ICountryRepository
    {
        public Country GetById(Guid id);
        public IList<Country> GetCountries();
    }
}
