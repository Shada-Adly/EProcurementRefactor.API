using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace EProcurementRefactor.Application.CQRS.Quieries.Handlers
{
    internal sealed class GetMaterialPackageLinesHandler
        : IQueryRequestHandler<GetMaterialPackageLinesQuery, List<MaterialPackageLinesResponseDto>>
    {
        private readonly IGenericGetSapPackageLinesService _genericGetSapPackageLinesService;
        private readonly SapIntegration _options;
        public GetMaterialPackageLinesHandler(
            IGenericGetSapPackageLinesService genericGetSapPackageLinesService,
            IOptions<SapIntegration> options)
        {
            _genericGetSapPackageLinesService = genericGetSapPackageLinesService;
            _options = options.Value;
        }
        public async Task<List<MaterialPackageLinesResponseDto>> HandlerAsync(
            GetMaterialPackageLinesQuery request,
            CancellationToken cancellationToken)
        {
            var url = _options.BaseUrl
                .Replace("{projectId}", request.SapPackageParametersDTO.project_num)
                .Replace("{indParam}", "1");

            var materialLines = await _genericGetSapPackageLinesService
                .GetPackageLinesAsync<MaterialPackageLinesResponseDto>(
                    request.SapPackageParametersDTO
                    , url);

            return materialLines;
        }
    }
}
