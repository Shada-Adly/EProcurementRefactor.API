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

            //if (createMaterialPackageDto.file != null)
            //{
            //    string packagesFolder = Path.Combine(
            //        _environment.WebRootPath, "packages");

            //    Directory.CreateDirectory(packagesFolder);

            //    string fileName = Path.GetFileName(createMaterialPackageDto.file.FileName);
            //    string filePath = Path.Combine(packagesFolder, fileName);

            //    using var stream = new FileStream(filePath, FileMode.Create);
            //    await createMaterialPackageDto.file.CopyToAsync(stream, cancellationToken);

            //    createMaterialPackageDto.filePath =
            //        filePath.Substring(
            //            filePath.IndexOf("wwwroot", StringComparison.Ordinal))
            //        .Replace('\\', '/');
            //}
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

                //createServicePackageDto.filePath =
                //    filePath.Substring(
                //        filePath.IndexOf("wwwroot", StringComparison.Ordinal))
                //    .Replace('\\', '/');
            }
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

            //if (createMaterialPackageManualDTO.file != null)
            //{
            //    string folderPath = Path.Combine(
            //        _environment.WebRootPath,
            //        "packages");

            //    if (!Directory.Exists(folderPath))
            //        Directory.CreateDirectory(folderPath);

            //    string fileName = Guid.NewGuid() + Path.GetExtension(createMaterialPackageManualDTO.file.FileName);

            //    string fullPath = Path.Combine(folderPath, fileName);

            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        await createMaterialPackageManualDTO.file.CopyToAsync(stream, cancellationToken);
            //    }

            //    createMaterialPackageManualDTO.filePath = Path.Combine("wwwroot", "packages", fileName)
            //        .Replace("\\", "/");
            //}

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

            //if (createServicePackageManualDTO.file != null)
            //{
            //    string folderPath = Path.Combine(
            //        _environment.WebRootPath,
            //        "packages");

            //    if (!Directory.Exists(folderPath))
            //        Directory.CreateDirectory(folderPath);

            //    string fileName = Guid.NewGuid() + Path.GetExtension(createServicePackageManualDTO.file.FileName);

            //    string fullPath = Path.Combine(folderPath, fileName);

            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        await createServicePackageManualDTO.file.CopyToAsync(stream, cancellationToken);
            //    }

            //    createServicePackageManualDTO.filePath = Path.Combine("wwwroot", "packages", fileName)
            //        .Replace("\\", "/");
            //}

            var result = await _mediator.
                SendCommandAsync<CreateServicePackageManualCommand, int>
                (new CreateServicePackageManualCommand(createServicePackageManualDTO),
                cancellationToken);
            return Ok(result);
        }
    }
}