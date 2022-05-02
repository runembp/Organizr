﻿using MediatR;
using Organizr.Core.Entities;

namespace Organizr.Application.Requests;

public class GetAllOrganizrUserRequest : IRequest<List<OrganizrUser>>
{
}

