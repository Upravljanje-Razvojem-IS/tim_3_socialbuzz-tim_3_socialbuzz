using AddressService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressService.Repositories
{
    public interface ICityRepository
    {
        public City SaveCity(City city);
        public IList<City> GetCitiesForQuery(IQueryable<City> query);
        public IQueryable<City> GetBasicQuery();
        public void DeleteCity(City city);
        public City GetById(Guid id);
        public City UpdateCity(City city);
    }
}
