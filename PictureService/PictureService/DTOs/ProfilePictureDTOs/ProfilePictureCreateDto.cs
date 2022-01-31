using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.ProfilePictureDTOs
{
    public class ProfilePictureCreateDto
    {

        public string Url { get; set; }
        public Guid OwnerId { get; set; }

        public DateTime SetAsProfilePicture { get; set; }
    
    }
}
