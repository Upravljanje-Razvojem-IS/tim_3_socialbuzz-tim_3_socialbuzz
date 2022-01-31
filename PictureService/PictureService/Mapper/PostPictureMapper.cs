using AutoMapper;
using PictureService.DTOs.PostDTOs;
using PictureService.DTOs.PostPictureDTOs;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Mapper
{
    public class PostPictureMapper: Profile
    {
        public PostPictureMapper()
        {
            CreateMap<PostPicture, PostPictureReadDto>().ReverseMap();
            CreateMap<PostPicture, PostConfirmationDto>().ReverseMap();
        }
    }
}
