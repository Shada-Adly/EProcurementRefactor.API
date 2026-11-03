using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace EProcurementRefactor.Application.CQRS.Quieries.Handlers
{
    internal sealed class GetServicePackageLinesHandler
    : IQueryRequestHandler<
        GetServicePackageLinesQuery,
        List<ServicePackageLinesResponseDto>>
    {
        private readonly IGenericGetSapPackageLinesService _genericGetSapPackageLinesService;
        private readonly SapIntegration _options;

        public GetServicePackageLinesHandler(
            IGenericGetSapPackageLinesService genericGetSapPackageLinesService,
            IOptions<SapIntegration> options)
        {
            _genericGetSapPackageLinesService = genericGetSapPackageLinesService;
            _options = options.Value;
        }
        public async Task<List<ServicePackageLinesResponseDto>> HandlerAsync(
            GetServicePackageLinesQuery request,
            CancellationToken cancellationToken)
        {
            var url = _options.BaseUrl
                .Replace("{projectId}",request.SapPackageParametersDTO.project_num)
                .Replace("{indParam}","2");

            var serviceLines = await _genericGetSapPackageLinesService
                .GetPackageLinesAsync<ServicePackageLinesResponseDto>(
                    request.SapPackageParametersDTO
                    , url);

            return serviceLines;
        }
    }
}
