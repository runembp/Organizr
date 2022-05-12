using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class UpdateMemberGroupHandler : IRequestHandler<UpdateMemberGroupCommand, MemberGroup>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMemberGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MemberGroup> Handle(UpdateMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var group = _mapper.Map<MemberGroup>(command);
        return await _unitOfWork.GroupRepository.UpdateMemberGroup(group);
    }
}