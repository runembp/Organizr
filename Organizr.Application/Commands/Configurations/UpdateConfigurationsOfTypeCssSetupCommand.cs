using MediatR;
using Organizr.Application.Responses.Configurations;

namespace Organizr.Application.Commands.Configurations;

public class UpdateConfigurationsOfTypeCssSetupCommand : IRequest<UpdateConfigurationsResponse>
{
    public string? StringValue { get; init; }
}