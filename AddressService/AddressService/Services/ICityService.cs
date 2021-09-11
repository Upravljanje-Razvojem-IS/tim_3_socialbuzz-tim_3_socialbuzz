using AddressService.Dtos.City;
using System;
using System.Collections.Generic;

namespace AddressService.Services
{
    public interface ICityService
    {
        public IList<CityDto> GetCities();
        public CityDto GetById(Guid id);
        public CityDto SaveCity(SaveCityDto cityDto);
        public CityDto UpdateCity(Guid id, UpdateCityDto cityDto);
        public void DeleteCity(Guid id);
    }
}
