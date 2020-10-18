using AutoMapper;
using IncidentApp.Models;
using IncidentApp.Models.Dtos;

namespace IncidentApp.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
