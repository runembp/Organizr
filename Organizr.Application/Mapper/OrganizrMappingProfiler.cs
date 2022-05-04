using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Core.Entities;

namespace Organizr.Application.Mapper;

public class OrganizrMappingProfiler : Profile
{
    public OrganizrMappingProfiler()
    {
        CreateMap<Member, CreateMemberCommand>().ReverseMap();
        CreateMap<MemberGroup, CreateMemberGroupCommand>().ReverseMap();
    }
}

