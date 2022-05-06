using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Mapper;

public class OrganizrMappingProfiler : Profile
{
    public OrganizrMappingProfiler()
    {
        CreateMap<Member, CreateMemberCommand>().ReverseMap();
        CreateMap<MemberGroup, CreateMemberGroupCommand>().ReverseMap();
    }
}

