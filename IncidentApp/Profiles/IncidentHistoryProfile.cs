using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class IncidentHistoryProfile : Profile
    {
        public IncidentHistoryProfile()
        {
            CreateMap<IncidentHistory, IncidentHistoryDto>().ReverseMap();
        }
    }
}
