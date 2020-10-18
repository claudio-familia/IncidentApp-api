using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class PriorityProfile : Profile
    {
        public PriorityProfile()
        {
            CreateMap<Priority, PriorityDto>().ReverseMap();
        }
    }
}
