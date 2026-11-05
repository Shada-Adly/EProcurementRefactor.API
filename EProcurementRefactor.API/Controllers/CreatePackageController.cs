using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.CQRS.Commands;
using EProcurementRefactor.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EProcurementRefactor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreatePackageController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _environment;

        public CreatePackageController(
            IMediator mediator,
            IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _environment = environment;
        }
        [HttpPost("CreateMaterialPackage")]
        public async Task<IActionResult> CreateMaterialPackage(
            [FromBody] CreateMaterialPackageDto createMaterialPackageDto,
            CancellationToken cancellationToken)
        {

            createMaterialPackageDto.assigned_by = 1;

            var result = await _mediator.
                SendCommandAsync<CreateMaterialPackageCommand, int>
                (new CreateMaterialPackageCommand(createMaterialPackageDto),
                cancellationToken);

            return Ok(result);
        }

        [HttpPost("CreateServicePackage")]
        public async Task<IActionResult> CreateServicePackage(
            [FromBody] CreateServicePackageDto createServicePackageDto,
            CancellationToken cancellationToken)
        {

            createServicePackageDto.assigned_by = 1;

            var result = await _mediator.
                SendCommandAsync<CreateServicePackageCommand, int>
                (new CreateServicePackageCommand(createServicePackageDto),
                cancellationToken);

            return Ok(result);
        }

        [HttpPost("CreateMaterialPackageManual")]
        public async Task<IActionResult> CreateMaterialPackageManual(
            [FromBody] CreateMaterialPackageManualDTO createMaterialPackageManualDTO,
            CancellationToken cancellationToken)
        {
            createMaterialPackageManualDTO.assigned_by = 1;

            var result = await _mediator.
                SendCommandAsync <CreateMaterialPackageManualCommand, int>
                (new CreateMaterialPackageManualCommand(createMaterialPackageManualDTO),
                cancellationToken);
            return Ok(result);
        }

        [HttpPost("CreateServicePackageManual")]
        public async Task<IActionResult> CreateServicePackageManual(
            [FromBody] CreateServicePackageManualDTO createServicePackageManualDTO,
            CancellationToken cancellationToken)
        {
            createServicePackageManualDTO.assigned_by = 1;

            var result = await _mediator.
                SendCommandAsync<CreateServicePackageManualCommand, int>
                (new CreateServicePackageManualCommand(createServicePackageManualDTO),
                cancellationToken);
            return Ok(result);
        }
    }
}