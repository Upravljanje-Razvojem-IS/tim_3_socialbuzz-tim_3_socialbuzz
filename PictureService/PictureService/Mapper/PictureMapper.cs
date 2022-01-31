using AutoMapper;
using PictureService.DTOs.PictureDTOs;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Mapper
{
    public class PictureMapper :Profile
    {
        public PictureMapper()
        {
            CreateMap<Picture, PictureReadDto>().ReverseMap();
            CreateMap<Picture, PictureConfirmationDto>().ReverseMap();

        }
    }
}
