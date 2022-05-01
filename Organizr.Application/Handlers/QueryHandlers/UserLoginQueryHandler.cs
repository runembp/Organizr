using AutoMapper;
using MediatR;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.QueryHandlers;

public class UserLoginQueryHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    // private readonly AuthenticationHelperClass _authenticationHelperClass;
    // private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserLoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

        response.Email = user.Email;
        // response.Token = await _authenticationHelperClass.GenerateToken(user);
        response.Succeeded = signInResult.Succeeded;
        
        // await _authenticationHelperClass.HandleLocalStorageAuthentication(response);
        
        // ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(response.Email);

        return response;
    }
}