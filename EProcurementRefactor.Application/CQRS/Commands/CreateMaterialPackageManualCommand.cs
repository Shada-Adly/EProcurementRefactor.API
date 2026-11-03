using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;

namespace EProcurementRefactor.Application.CQRS.Commands
{
    public record CreateMaterialPackageManualCommand(CreateMaterialPackageManualDTO createMaterialPackageManualDTO)
        : ICommandRequest<int>;
}
