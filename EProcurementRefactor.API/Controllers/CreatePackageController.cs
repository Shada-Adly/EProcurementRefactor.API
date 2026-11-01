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
            [FromForm] CreateMaterialPackageDto createMaterialPackageDto,
            IFormFile? file,
            CancellationToken cancellationToken)
        {


            createMaterialPackageDto.assigned_by = 1;

            if (file != null)
            {
                string packagesFolder = Path.Combine(
                    _environment.WebRootPath, "packages");

                Directory.CreateDirectory(packagesFolder);

                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(packagesFolder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream, cancellationToken);

                createMaterialPackageDto.filePath =
                    filePath.Substring(
                        filePath.IndexOf("wwwroot", StringComparison.Ordinal))
                    .Replace('\\', '/');
            }
            var result = await _mediator.
                SendCommandAsync<CreateMaterialPackageCommand, int>
                (new CreateMaterialPackageCommand(createMaterialPackageDto),
                cancellationToken);

            return Ok(result);
        }
        [HttpPost("CreateServicePackage")]
        public async Task<IActionResult> CreateServicePackage(
            [FromForm] CreateServicePackageDto createServicePackageDto,
            IFormFile? file,
            CancellationToken cancellationToken)
        {

            createServicePackageDto.assigned_by = 1;

            if (file != null)
            {
                string packagesFolder = Path.Combine(
                    _environment.WebRootPath, "packages");

                Directory.CreateDirectory(packagesFolder);

                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(packagesFolder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream, cancellationToken);

                createServicePackageDto.filePath =
                    filePath.Substring(
                        filePath.IndexOf("wwwroot", StringComparison.Ordinal))
                    .Replace('\\', '/');
            }
            var result = await _mediator.
                SendCommandAsync<CreateServicePackageCommand, int>
                (new CreateServicePackageCommand(createServicePackageDto),
                cancellationToken);

            return Ok(result);
        }
    }
}