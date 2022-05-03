using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;

namespace Organizr.Application.Mapper;

public class OrganizrMappingProfiler : Profile
{
    public OrganizrMappingProfiler()
    {
        CreateMap<OrganizrUser, CreateUserResponse>().ReverseMap();
        CreateMap<OrganizrUser, CreateUserCommand>().ReverseMap();
    }
}

