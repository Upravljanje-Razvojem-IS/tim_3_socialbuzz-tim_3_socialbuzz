using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.PostPictureDTOs
{
    public class PostPictureConfirmationDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string PictureType { get; set; }
        public Guid PostId { get; set; }
    }
}
