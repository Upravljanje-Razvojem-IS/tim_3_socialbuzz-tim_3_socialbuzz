using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Entities
{
    public class ProfilePicture : Picture
    {
        
        
        public Guid OwnerId { get; set; }
        public string Url { get; set; }
        public DateTime SetAsProfilePicture { get; set; }
        public virtual Owner Owner {get;set;}
    }
}
