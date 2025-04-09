using AutoMapper;
using TaskManagementApp.DtoLayer.Dtos.TaskItemDtos;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Mapping.AutoMapperProfiles
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<CreateTaskItemDto, TaskItem>();
            CreateMap<TaskItem, ResultTaskItemDto>()
                .ForMember(dest => dest.AssignedToUser, opt => opt.MapFrom(src => src.AssignedToUser.FullName));
        }
    }
}
