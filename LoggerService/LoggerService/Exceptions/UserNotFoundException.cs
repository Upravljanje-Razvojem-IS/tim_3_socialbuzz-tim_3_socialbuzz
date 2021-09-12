using System;

namespace LoggerService.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid id)
            : base($"User with the id: {id} doesn't exist")
        {}
    }
}
