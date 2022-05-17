using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Members;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Member;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Members;

public class UpdateMemberHandler : IRequestHandler<UpdateMemberCommand, UpdateMemberResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMemberHandler( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateMemberResponse> Handle(UpdateMemberCommand command, CancellationToken cancellationToken)
    {
        var response = new UpdateMemberResponse();
        
        var updatedMember = _mapper.Map<Member>(command);

        if (updatedMember is null)
        {
            response.Error = "Medlem er ikke i et korrekt format";
            return response;
        }

        var result = await _unitOfWork.MemberRepository.UpdateMember(updatedMember);

        if (result is null)
        {
            response.Error = "Medlemmet findes ikke";
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}