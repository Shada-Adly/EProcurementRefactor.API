using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.Interfaces;

namespace EProcurementRefactor.Application.CQRS.Commands.Handlers
{
    public class CreateServicePackageManualHandler : ICommandRequestHandler<CreateServicePackageManualCommand, int>
    {
        private readonly ICreatePackageService _createPackageService;

        public CreateServicePackageManualHandler(ICreatePackageService createPackageService)
        {
            _createPackageService = createPackageService;
        }
        public Task<int> HandlerAsync(
            CreateServicePackageManualCommand request,
            CancellationToken cancellationToken = default)
        {
            var result = _createPackageService.CreateServicePackageManual(
                request.createServicePackageManualDTO,
                cancellationToken);

            return result;
        }
    }
}
