using System;

namespace AddressService.Exceptions
{
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(Guid id)
            : base($"Country with id: {id} doesn't exist")
        {}
    }
}
