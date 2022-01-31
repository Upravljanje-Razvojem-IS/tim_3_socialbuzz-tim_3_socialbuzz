using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.PostDTOs
{
    public class PostReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
