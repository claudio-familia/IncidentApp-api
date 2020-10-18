using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class SLAProfile : Profile
    {
        public SLAProfile()
        {
            CreateMap<SLA, SLADto>().ReverseMap();
        }
    }
}
