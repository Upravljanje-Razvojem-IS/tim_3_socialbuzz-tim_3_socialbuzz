using AutoMapper;
using PictureService.DTOs.ProfilePictureDTOs;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Mapper
{
    public class ProfilePictureMapper:Profile
    {
        public ProfilePictureMapper()
        {
            CreateMap<ProfilePicture, ProfilePictureReadDto>().ReverseMap();
            CreateMap<ProfilePicture, ProfilePictureConfirmationDto>().ReverseMap();
        }
    }
}
