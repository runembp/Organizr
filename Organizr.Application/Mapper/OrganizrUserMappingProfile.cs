using AutoMapper;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;

namespace Organizr.Application.Mapper
{
    public class OrganizrUserMappingProfile : Profile
    {
        public OrganizrUserMappingProfile()
        {
            CreateMap<OrganizrUser, OrganizrUserResponse>().ReverseMap();
            CreateMap<OrganizrUser, CreateOrganizrUserCommand>().ReverseMap();
        }
    }
}
