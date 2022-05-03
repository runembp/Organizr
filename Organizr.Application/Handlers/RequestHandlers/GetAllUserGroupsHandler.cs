﻿using MediatR;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.RequestHandlers;

public class GetAllUserGroupsHandler : IRequestHandler<GetAllUserGroupsRequest, GetAllUserGroupsResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserGroupsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Task<GetAllUserGroupsResponse> Handle(GetAllUserGroupsRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllUserGroupsResponse
        {
            UserGroups = _unitOfWork.UserGroupRepository.GetAll().Result
        };

        return Task.FromResult(response);
    }
}