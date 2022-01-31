using AutoMapper;
using BlockService.DTOs;
using BlockService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Mapper
{
    public class UserBlockProfile:Profile
    {
        public UserBlockProfile()
        {
            CreateMap<UserBlock, UserBlockReadDto>().ReverseMap() ;
            CreateMap<UserBlock, UserBlockConfirmationDto>().ReverseMap();
        }
    }
}
