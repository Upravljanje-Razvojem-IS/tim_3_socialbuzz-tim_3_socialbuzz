using AddressService.Dtos.Country;
using System;

namespace AddressService.Dtos.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public CountryDto Country { get; set; }
    }
}
