using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;

namespace EProcurementRefactor.Application.CQRS.Quieries
{
    public record AdminLoginQuery(AdminLoginDto adminLoginDto) : IQueryRequest<LoginResponseDto>;
}
