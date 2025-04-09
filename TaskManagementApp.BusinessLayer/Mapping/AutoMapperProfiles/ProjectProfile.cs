using AutoMapper;
using TaskManagementApp.DtoLayer.Dtos.ProjectDtos;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Mapping.AutoMapperProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectDto, Project>();
            CreateMap<Project, ResultProjectDto>();
        }
    }
}
