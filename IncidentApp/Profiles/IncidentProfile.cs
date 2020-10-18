using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            CreateMap<Incident, IncidentDto>().ReverseMap();
        }
    }
}
