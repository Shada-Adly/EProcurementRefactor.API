using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.Interfaces;

namespace EProcurementRefactor.Application.CQRS.Commands.Handlers
{
    public class CreateMaterialPackageManualHandler : ICommandRequestHandler<CreateMaterialPackageManualCommand, int>
    {
        private readonly ICreatePackageService _createPackageService;

        public CreateMaterialPackageManualHandler(ICreatePackageService createPackageService)
        {
            _createPackageService = createPackageService;
        }
        public Task<int> HandlerAsync(
            CreateMaterialPackageManualCommand request,
            CancellationToken cancellationToken = default)
        {
           var result = _createPackageService.CreateMaterialPackageManual(
                request.createMaterialPackageManualDTO ,
                cancellationToken);

            return result;
        }
    }
}
