using AutoMapper;
using NorthArena.Dtos;
using NorthArena.Models;

namespace NorthArena.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AboutUsDto, AboutUS>();
            CreateMap<IntroDto, Intro>();

            CreateMap<SustainabilityDto, Sustainability>();
        }
    }
}
