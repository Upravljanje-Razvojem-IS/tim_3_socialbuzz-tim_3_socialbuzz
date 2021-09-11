using AddressService.Dtos.Country;
using System;
using System.Collections.Generic;

namespace AddressService.Services
{
    public interface ICountryService
    {
        public IList<CountryDto> GetCountries();
        public CountryDto GetById(Guid id);
    }
}
