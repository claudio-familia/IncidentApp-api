using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDto>().ReverseMap();
        }
    }
}
