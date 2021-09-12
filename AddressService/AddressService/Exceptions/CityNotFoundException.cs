using System;

namespace AddressService.Exceptions
{
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException(Guid id)
            : base($"City with id:  {id} doesn't exist")
        { }
    }
}
