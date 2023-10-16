using AutoMapper;
using DAL.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.MappingProfiels
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeVM, Empolyee>().ReverseMap();
        }
    }
}