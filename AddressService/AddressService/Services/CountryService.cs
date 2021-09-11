using AddressService.Dtos.Country;
using AddressService.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AddressService.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }
        public CountryDto GetById(Guid id)
        {
            var country = _countryRepo.GetById(id);

            if (country == null)
            {
                throw new Exception($"Country with id: {id} doesnt exist");
            }

            return _mapper.Map<CountryDto>(country);
        }

        public IList<CountryDto> GetCountries()
        {
            return _mapper.Map<IList<CountryDto>>(_countryRepo.GetCountries());
        }
    }
}
