using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;

namespace EProcurementRefactor.Application.CQRS.Commands
{
    public record CreateServicePackageManualCommand(CreateServicePackageManualDTO createServicePackageManualDTO)
        :ICommandRequest<int>;
}
