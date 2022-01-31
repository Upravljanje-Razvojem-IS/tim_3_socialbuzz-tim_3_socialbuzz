using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.DTOs
{
    public class UserBlockCreateDto
    {
        public Guid BlockerId { get; set; }
        public Guid BlockedId { get; set; }

}
}
