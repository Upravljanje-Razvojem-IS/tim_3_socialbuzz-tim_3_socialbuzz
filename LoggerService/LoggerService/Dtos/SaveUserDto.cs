using System;

namespace LoggerService.Dtos
{
    public class SaveUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
