using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hostel.Application.Helpers.Authentification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Hostel.Application.Authentication.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterUserCommandHandler : IRequestHandler<LoginUserCommand,string>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly IJwtManager _jwtManager;

        public RegisterUserCommandHandler(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager, IJwtManager jwtManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtManager = jwtManager;
        }
        
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw new Exception("Login error");
            
            var res =await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!res.Succeeded) throw new Exception("Login error");
            
            return  await _jwtManager.CreateJwt(user.Id, user.Email);
        }
    }
}