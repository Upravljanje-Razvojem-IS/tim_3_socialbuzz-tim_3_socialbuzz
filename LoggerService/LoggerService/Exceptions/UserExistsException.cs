using System;

namespace LoggerService.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException(Guid id) 
            : base($"User with id: {id} already exists") 
        {}
    }
}
