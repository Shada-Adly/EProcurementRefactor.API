using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace EProcurementRefactor.Application.CQRS.Quieries.Handlers
{
    internal sealed class GetPackageLinesHandler
        : IQueryRequestHandler<GetPackageLinesQuery, List<IPackageLinesCommonProperitiesInterface>>
    {
        private readonly IGenericGetSapPackageLinesService _sapService;
        private readonly SapIntegration _options;
        public GetPackageLinesHandler(
            IGenericGetSapPackageLinesService sapService,
            IOptions<SapIntegration> options)
        {
            _sapService = sapService;
            _options = options.Value;
        }
        public async Task<List<IPackageLinesCommonProperitiesInterface>> HandlerAsync(
            GetPackageLinesQuery request, 
            CancellationToken cancellationToken)
        {

            var parameters = request.SapPackageParametersDTO;

            if (parameters?.inudstries == null ||
                parameters.inudstries.Count == 0 ||
                parameters.inudstries[0] == null ||
                string.IsNullOrWhiteSpace(
                    parameters.inudstries[0].IndustryCode))
            {
                throw new ArgumentException(
                    "At least one valid industry is required.");
            }

            var isMaterial = parameters.inudstries[0]
                .IndustryCode.Contains('M');

            var indParam = isMaterial ? "1" : "2";

            var url = _options.BaseUrl
                .Replace("{projectId}", parameters.project_num)
                .Replace("{indParam}", indParam);

            if (isMaterial)
            {
                var result = await _sapService
                    .GetPackageLinesAsync<MaterialPackageLinesResponseDto>(
                        parameters, url);

                return result
                     .Select(x => (IPackageLinesCommonProperitiesInterface)x)
                     .ToList();
            }

            var serviceResult = await _sapService
                .GetPackageLinesAsync<ServicePackageLinesResponseDto>(
                    parameters, url);

            return serviceResult
                .Select(x => (IPackageLinesCommonProperitiesInterface)x)
                .ToList();
        }
    }
}
