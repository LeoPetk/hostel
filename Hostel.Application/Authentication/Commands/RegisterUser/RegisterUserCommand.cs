using System;
using System.Threading;
using System.Threading.Tasks;
using Hostel.Application.Common.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hostel.Application.Authentication.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        // We need to add etc...
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        
        public RegisterUserCommandHandler(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
                var user = new IdentityUser<Guid>()
                {
                    UserName = request.UserName,
                    NormalizedUserName = request.UserName.ToUpper(),
                    TwoFactorEnabled = false,
                    LockoutEnabled = false
                };

               var res =  await _userManager.CreateAsync(user, request.Password);
            
               return Unit.Value;
        }
    }
}