using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Core.Entities;

namespace Organizr.Application.Mapper;

public class OrganizrMappingProfiler : Profile
{
    public OrganizrMappingProfiler()
    {
        CreateMap<OrganizrUser, CreateUserCommand>().ReverseMap();
        CreateMap<UserGroup, CreateUserGroupCommand>().ReverseMap();
    }
}

