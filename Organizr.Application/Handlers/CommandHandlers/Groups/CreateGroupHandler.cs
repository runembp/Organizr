using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class CreateMemberGroupCommandHandler : IRequestHandler<CreateMemberGroupCommand, MemberGroup?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMemberGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MemberGroup?> Handle(CreateMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var group = _mapper.Map<MemberGroup>(command);

        if (group is null)
        {
            return null;
        }

        if (await _unitOfWork.GroupRepository.GroupExists(command.Name))
        {
            return null;
        }

        var result = await _unitOfWork.GroupRepository.Add(group);

        return result;
    }
}