using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Members;

public class GetAllMembersWithNoMembershipInGroupRequest : IRequest<List<Member>> 
{
    public int GroupId { get; init; } 
}