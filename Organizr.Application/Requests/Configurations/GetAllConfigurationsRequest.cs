using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Configurations;

public class GetAllConfigurationsRequest : IRequest<List<Configuration>>
{
}

