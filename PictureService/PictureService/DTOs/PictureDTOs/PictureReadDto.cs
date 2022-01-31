using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.PictureDTOs
{
    public class PictureReadDto
    {
        public Guid Id { get; set; }

        public string Url { get; set; }
    }
}
