using AutoMapper;
using TaskManagementApp.DtoLayer.Dtos.UserDtos;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Mapping.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, ResultUserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
        }
    }
}
