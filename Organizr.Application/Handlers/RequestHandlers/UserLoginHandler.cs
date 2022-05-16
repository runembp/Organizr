using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.HelperClasses;
using Organizr.Application.Requests;
using Organizr.Application.Responses;

namespace Organizr.Application.Handlers.RequestHandlers;

public class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenHelperClass _tokenHelperClass;

    public UserLoginHandler(IUnitOfWork unitOfWork, TokenHelperClass tokenHelperClass)
    {
        _unitOfWork = unitOfWork;
        _tokenHelperClass = tokenHelperClass;
    }

    public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var response = new UserLoginResponse { Succeeded = false };
        
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password)) 
        {
            response.Error = "Brugernavn eller password er ikke udfyldt korrekt";
            return response;
        }

        var user = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            response.Error = "Bruger kunne ikke findes";
            return response;
        }

        var signInResult = await _unitOfWork.SignInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!signInResult.Succeeded)
        {
            response.Error = "Brugernavn eller password er forkert";
            return response;
        }

        response.Email = user.Email;
        response.Id = user.Id;
        response.Succeeded = signInResult.Succeeded;
        response.Token = await _tokenHelperClass.GenerateToken(user);

        return response;
    }
}