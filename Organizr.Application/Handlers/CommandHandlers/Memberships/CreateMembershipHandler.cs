using MediatR;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Handlers.CommandHandlers.Memberships;

public class CreateMembershipHandler : IRequestHandler<CreateMembershipCommand, CreateMembershipResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMembershipHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateMembershipResponse> Handle(CreateMembershipCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateMembershipResponse();

        var result = await _unitOfWork.MembershipRepository.CreateMembership(command);

        if (result is null)
        {
            response.Error = "Gruppe id eller Medlems id er ikke udfyldt korrekt";
            return response;
        }

        response.Succeeded = true;
        response.CreatedMembership = result;
        return response;
    }
}