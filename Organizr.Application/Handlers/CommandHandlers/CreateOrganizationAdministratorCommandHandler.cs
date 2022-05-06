using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses;
using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;


namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizationAdministratorCommandHandler : IRequestHandler<CreateMemberCommand, CreateMemberResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrganizationAdministratorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateMemberResponse> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Member>(command);

        var response = new CreateMemberResponse { Succeeded = false };

        if (user is null)
        {
            return response;
        }

        var result = await _unitOfWork.UserManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            response.Succeeded = result.Succeeded;
            response.Errors = result.Errors.ToList();
            return response;
        }

        result = await _unitOfWork.UserManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);

        if (!result.Succeeded)
        {
            response.Succeeded = result.Succeeded;
            response.Errors = result.Errors.ToList();
            return response;
        }

        response.Succeeded = result.Succeeded;
        return response;
    }
}