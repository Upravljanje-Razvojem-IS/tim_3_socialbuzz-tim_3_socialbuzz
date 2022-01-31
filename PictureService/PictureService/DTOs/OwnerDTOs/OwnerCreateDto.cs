using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.DTOs.OwnerDTOs
{
    public class OwnerCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

      /*  public virtual ProfilePicture ProfilePicture { get; set; }*/

    }
}
