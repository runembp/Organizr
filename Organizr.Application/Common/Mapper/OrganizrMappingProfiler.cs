using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Commands.Members;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Mapper;

public class OrganizrMappingProfiler : Profile
{
    public OrganizrMappingProfiler()
    {
        CreateMap<Member, CreateMemberCommand>().ReverseMap();
        CreateMap<Member, UpdateMemberCommand>().ReverseMap();
        CreateMap<MemberGroup, CreateMemberGroupCommand>().ReverseMap();
        CreateMap<MemberGroup, UpdateMemberGroupCommand>().ReverseMap();
    }
}
