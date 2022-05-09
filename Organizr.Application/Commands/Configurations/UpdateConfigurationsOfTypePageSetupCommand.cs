using MediatR;
using Organizr.Application.Responses.Configurations;
using Organizr.Domain.Entities;

namespace Organizr.Application.Commands.Configurations;

public class UpdateConfigurationsOfTypePageSetupCommand : IRequest<UpdateConfigurationsResponse>
{
    public Configuration Frontpage { get; set; }
    public Configuration CreateMembership { get; set; }
    public Configuration AboutUs { get; set; }
    public Configuration Contact { get; set; }
}