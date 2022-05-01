using AutoMapper;
using MediatR;
using Organizr.Application.HelperClasses;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.QueryHandlers;

public class UserLoginAsOrganizationAdministratorHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly AuthenticationHelperClass _authenticationHelperClass;
    
    public UserLoginAsOrganizationAdministratorHandler(IMapper mapper, IUnitOfWork unitOfWork, AuthenticationHelperClass authenticationHelperClass)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _authenticationHelperClass = authenticationHelperClass;
    }
    
    public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
        
        var response = new UserLoginResponse();
        
        if (user is null)
        {
            response.Succeeded = false;
            return response;
        }

        var signInResult = await _unitOfWork.SignInManager.CheckPasswordSignInAsync(user, request.Password, false);
        
        if (!signInResult.Succeeded)
        {
            response.Succeeded = false;
            return response;
        }
        
        var isOrganizationAdministrator = await _unitOfWork.UserManager.IsInRoleAsync(user, ApplicationConstants.OrganizationAdministrator);
        
        if (!isOrganizationAdministrator)
        {
            response.Succeeded = false;
            return response;
        }
        
        response.Email = request.Email;
        response.Token = await _authenticationHelperClass.GenerateToken(user);
        response.Succeeded = signInResult.Succeeded;
        
        await _authenticationHelperClass.HandleLocalStorageAuthentication(request, response);

        return response;
    }
}