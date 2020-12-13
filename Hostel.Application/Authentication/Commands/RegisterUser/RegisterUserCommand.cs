using System;
using System.Threading;
using System.Threading.Tasks;
using Hostel.Application.Common.Repository;
using Hostel.Domain.Entities;
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
        private readonly UserManager<User> _userManager;
        
        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
                var user = new User()
                {
                    UserName = request.UserName,
                    NormalizedUserName = request.UserName.ToUpper(),
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    // for now hardcoded hostel Id
                    HostelId = Guid.Parse("5E6EBA1D-AA73-4626-8B99-E1714E52ACAC")
                };

               var res =  await _userManager.CreateAsync(user, request.Password);
            
               return Unit.Value;
        }
    }
}