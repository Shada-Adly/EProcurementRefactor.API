using EProcurementRefactor.Application.DTOs;
using FluentValidation;

namespace EProcurementRefactor.Application.Validators
{
    public class AutomaticServicePackageValidator:AbstractValidator<CreateServicePackageDto>
    {
        public AutomaticServicePackageValidator()
        { 
            RuleFor(m => m.assign_type)
                .NotEmpty()
                .WithMessage("assign_type Field Can't Be Empty");

            RuleFor(m => m.currency)
                .NotEmpty()
                .WithMessage("currency Field Can't Be Empty");

            RuleFor(m => m.expiration_date)
                .NotEmpty()
                .WithMessage("expiration_date Field Can't Be Empty");

            RuleFor(m => m.industry_id)
                .NotEmpty()
                .WithMessage("industry_id Field Can't Be Empty");

            RuleFor(m => m.package_name)
                .NotEmpty()
                .WithMessage("package_name Field Can't Be Empty");

            RuleFor(m => m.project_id)
                .NotEmpty()
                .WithMessage("project_id Field Can't Be Empty");

            RuleFor(m => m.selected_rows)
                .NotEmpty()
                .WithMessage("selected_rows Field Can't Be Empty");

            RuleFor(m => m.type)
                .NotEmpty()
                .WithMessage("type Field Can't Be Empty");
        }
    }
}
