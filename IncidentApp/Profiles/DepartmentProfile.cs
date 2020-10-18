using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
