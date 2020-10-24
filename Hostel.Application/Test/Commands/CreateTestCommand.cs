using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hostel.Domain.Entities;
using MediatR;

namespace Hostel.Application.Test.Commands
{
    public class CreateTestCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }

    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, Unit>
    {
        public CreateTestCommandHandler()
        {
            
        }

        public async Task<Unit> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
           var testEntity = new TestEntity()
           {
               Id = 110,
               Name = request.Name
           };

           await Task.CompletedTask;
           return Unit.Value;
        }
    }
}
