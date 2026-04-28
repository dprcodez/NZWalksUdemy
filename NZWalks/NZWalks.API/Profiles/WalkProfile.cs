using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile() 
        {
          CreateMap<Walk,WalkDto>().ReverseMap();
        }
    }
}
