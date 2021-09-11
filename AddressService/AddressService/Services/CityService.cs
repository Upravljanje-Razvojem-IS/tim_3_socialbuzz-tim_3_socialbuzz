using AddressService.Dtos.City;
using AddressService.Models;
using AddressService.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AddressService.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepo, ICountryRepository countryRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

        public void DeleteCity(Guid id)
        {
            var city = _cityRepo.GetById(id);

            if (city == null)
            {
                throw new Exception($"City with id: {id} doesnt't exist");
            }

            _cityRepo.DeleteCity(city);
        }

        public CityDto GetById(Guid id)
        {
            var city = _cityRepo.GetById(id);

            if (city == null)
            {
                throw new Exception($"City with id: {id} doesnt't exist");
            }

            return _mapper.Map<CityDto>(city);
        }

        public IList<CityDto> GetCities()
        {
            return _mapper.Map<IList<CityDto>>(_cityRepo.GetCitiesForQuery(_cityRepo.GetBasicQuery()));
        }

        public CityDto SaveCity(SaveCityDto cityDto)
        {
            var country = _countryRepo.GetById(cityDto.CountryId);

            if (country == null)
            {
                throw new Exception($"Country with id: {cityDto.CountryId} doesn't exist");
            }

            var city = _mapper.Map<City>(cityDto);
            city.Country = country;

            return _mapper.Map<CityDto>(_cityRepo.SaveCity(city));
        }

        public CityDto UpdateCity(Guid id, UpdateCityDto cityDto)
        {
            var country = _countryRepo.GetById(cityDto.CountryId);

            if (country == null)
            {
                throw new Exception($"Country with id: {cityDto.CountryId} doesn't exist");
            }

            var city = _cityRepo.GetById(id);

            if (city == null)
            {
                throw new Exception($"City with id: {id} doenst't exist");
            }

            city.Name = cityDto.Name;
            city.ZipCode = cityDto.ZipCode;
            city.Country = country;
            city.Id = id;

            return _mapper.Map<CityDto>(_cityRepo.UpdateCity(city));
        }
    }
}
