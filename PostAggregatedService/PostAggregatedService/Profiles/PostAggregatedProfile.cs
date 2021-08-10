using AutoMapper;
using PostAggregatedService.Entities;
using PostAggregatedService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Profiles
{
    public class PostAggregatedProfile : Profile
    {
        public PostAggregatedProfile()
        {
            CreateMap<PostAggregated, PostAggregatedDto>();
            CreateMap<PostAggregated, PostAggregatedCreateDto>();
            CreateMap<PostAggregatedCreateDto, PostAggregated>();
            CreateMap<PostAggregatedUpdateDto, PostAggregated>();
            CreateMap<PostAggregatedDto, PostAggregatedUpdateDto>();
        }
    }
}
