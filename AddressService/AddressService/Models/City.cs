using System;

namespace AddressService.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public Country Country { get; set; }
    }
}
