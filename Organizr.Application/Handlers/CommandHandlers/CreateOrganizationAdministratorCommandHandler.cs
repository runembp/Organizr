using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;


namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizationAdministratorCommandHandler : IRequestHandler<CreateMemberCommand, Member?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrganizationAdministratorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Member?> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Member>(command);

        if (user is null)
        {
            return null;
        }

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return null;
        }

        result = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);

        if (!result.Succeeded)
        {
            return null;
        }

        var createdOrganizationAdministrator = await _unitOfWork.UserManager.FindByEmailAsync(command.Email);
        
        return createdOrganizationAdministrator;
    }
}