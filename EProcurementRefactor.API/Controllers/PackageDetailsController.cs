using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.CQRS.Quieries;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EProcurementRefactor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageDetailsController : Controller
    {
        private readonly IMediator _mediator;

        public PackageDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("GetMaterialPackageLines")]
        public async Task<IActionResult> GetMaterialPackageLines(
            [FromBody] SapPackageParametersDTO sapPackageParametersDTO,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.SendQueryAsync<
                GetMaterialPackageLinesQuery,
                List<MaterialPackageLinesResponseDto>>(
                    new GetMaterialPackageLinesQuery(sapPackageParametersDTO),
                    cancellationToken);

            return Ok(result);
        }

        [HttpPost("GetServicePackageLines")]
        public async Task<IActionResult> GetServicePackageLines(
            [FromBody] SapPackageParametersDTO sapPackageParametersDTO,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.SendQueryAsync<
                GetServicePackageLinesQuery,
                List<ServicePackageLinesResponseDto>>(
                    new GetServicePackageLinesQuery(sapPackageParametersDTO),
                    cancellationToken);

            return Ok(result);
        }
    }
}
