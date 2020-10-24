using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Hostel.Application.Test.Commands
{
    public class CreateTestCommandValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator()
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}
