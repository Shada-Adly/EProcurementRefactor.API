using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.Interfaces;

namespace EProcurementRefactor.Application.CQRS.Commands.Handlers
{
    public class CreateServicePackageHandler:ICommandRequestHandler<CreateServicePackageCommand,int>
    {
        private readonly ICreatePackageService _createPackageService;

        public CreateServicePackageHandler(ICreatePackageService createPackageService)
        {
            _createPackageService = createPackageService;
        }

        public Task<int> HandlerAsync(
            CreateServicePackageCommand request,
            CancellationToken cancellationToken = default)
        {
            var result = _createPackageService.CreateServicePackage(
                request.CreateServicePackageDto,
                cancellationToken);

            return result;
        }
    }
}
