using AutoMapper;
using TaskManagementApp.DtoLayer.Dtos.RoleDtos;
using TaskManagementApp.EntityLayer.Entities;

namespace TaskManagementApp.BusinessLayer.Mapping.AutoMapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, ResultRoleDto>();
        }
    }
}
