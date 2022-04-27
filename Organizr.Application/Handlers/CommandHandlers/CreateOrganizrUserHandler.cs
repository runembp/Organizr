using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Mapper;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories.Base;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizrUserHandler : IRequestHandler<CreateOrganizrUserCommand, OrganizrUserResponse>
{
    private readonly IOrganizrUserRepository _memberRepo;

    public CreateOrganizrUserHandler(IOrganizrUserRepository memberRepository)
    {
        _memberRepo = memberRepository;
    }
    public async Task<OrganizrUserResponse> Handle(CreateOrganizrUserCommand request, CancellationToken cancellationToken)
    {
        var memberEntity = OrganizrUserMapper.Mapper.Map<OrganizrUser>(request);
        if (memberEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var newEmployee = await _memberRepo.AddAsync(memberEntity);
        var employeeResponse = OrganizrUserMapper.Mapper.Map<OrganizrUserResponse>(newEmployee);
        return employeeResponse;
    }

}


