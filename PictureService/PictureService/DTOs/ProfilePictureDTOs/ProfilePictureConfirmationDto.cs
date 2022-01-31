using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.ProfilePictureDTOs
{
    public class ProfilePictureConfirmationDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid OwnerId { get; set; }

        public DateTime SetAsProfilePicture { get; set; }
    }
}
