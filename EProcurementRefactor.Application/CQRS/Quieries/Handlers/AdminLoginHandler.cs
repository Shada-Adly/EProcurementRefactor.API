using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using FluentValidation;

namespace EProcurementRefactor.Application.CQRS.Quieries.Handlers
{
    public class AdminLoginHandler : IQueryRequestHandler<AdminLoginQuery, LoginResponseDto>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IjwtTokenGenerator _jwtTokenGenerator;
        private readonly IValidator<AdminLoginDto> _validator;

        public AdminLoginHandler(
            IAdminRepository adminRepository,
            IjwtTokenGenerator jwtTokenGenerator,
            IValidator<AdminLoginDto> validator 
            )
        {
            _adminRepository = adminRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _validator = validator;
        }
        public async Task<LoginResponseDto> HandlerAsync(
            AdminLoginQuery request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.adminLoginDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
            }
            var admin = await _adminRepository.Login(request.adminLoginDto, cancellationToken);

            var token = _jwtTokenGenerator.GenerateToken(admin);

            return new LoginResponseDto
            {
                Name = admin.Username,
                Token=token
            };

        }
    }
}
