using AddressService.Dtos.City;
using AddressService.Exceptions;
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
                throw new CityNotFoundException(id);
            }

            _cityRepo.DeleteCity(city);
        }

        public CityDto GetById(Guid id)
        {
            var city = _cityRepo.GetById(id);

            if (city == null)
            {
                throw new CityNotFoundException(id);
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
                throw new CountryNotFoundException(cityDto.CountryId);
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
                throw new CountryNotFoundException(cityDto.CountryId);
            }

            var city = _cityRepo.GetById(id);

            if (city == null)
            {
                throw new CityNotFoundException(id);
            }

            city.Name = cityDto.Name;
            city.ZipCode = cityDto.ZipCode;
            city.Country = country;
            city.Id = id;

            return _mapper.Map<CityDto>(_cityRepo.UpdateCity(city));
        }
    }
}
