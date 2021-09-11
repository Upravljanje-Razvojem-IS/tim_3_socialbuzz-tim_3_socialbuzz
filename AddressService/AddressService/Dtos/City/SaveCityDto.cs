using System;

namespace AddressService.Dtos.City
{
    public class SaveCityDto
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public Guid CountryId { get; set; }
    }
}
