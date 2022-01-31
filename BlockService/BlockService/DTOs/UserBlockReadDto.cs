using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.DTOs
{
    public class UserBlockReadDto
    {
        public Guid Id { get; set; }
        public Guid BlockerId { get; set; }
        public Guid BlockedId { get; set; }

}
}
