using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.Interfaces;

namespace EProcurementRefactor.Application.CQRS.Commands.Handlers
{
    public class CreateMaterialPackageHandler : ICommandRequestHandler<CreateMaterialPackageCommand, int>
    {
        private readonly ICreatePackageService _createPackageService;

        public CreateMaterialPackageHandler(ICreatePackageService createPackageService)
        {
            _createPackageService = createPackageService;
        }
        public async Task<int> HandlerAsync(
            CreateMaterialPackageCommand request,
            CancellationToken cancellationToken = default)
        {
            var result = await _createPackageService.CreateMaterialPackage(
                request.CreateMaterialPackageDto,
                cancellationToken);

            return result;
        }
    }
}
