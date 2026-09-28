using EProcurementRefactor.Application.DTOs;
using FluentValidation;

namespace EProcurementRefactor.Application.Validators
{
    public class LoginValidator : AbstractValidator<AdminLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty();

            RuleFor(x => x.password)
                .NotEmpty();
        }
    }
}
