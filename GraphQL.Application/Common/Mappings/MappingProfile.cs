using AutoMapper;
using GraphQL.Application.Common.DTOs;
using GraphQL.Domain.Entities;

namespace GraphQL.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
