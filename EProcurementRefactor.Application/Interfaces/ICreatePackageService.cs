using EProcurementRefactor.Application.DTOs;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface ICreatePackageService
    {
        Task<int> CreateMaterialPackage(
            CreateMaterialPackageDto createMaterialPackageDto,
            CancellationToken cancellationToken);
        Task<int> CreateServicePackage(
            CreateServicePackageDto createServicePackageDto,
            CancellationToken cancellationToken);
        Task<int> CreateMaterialPackageManual(
            CreateMaterialPackageManualDTO createMaterialPackageManualDTO,
            CancellationToken cancellationToken);
        Task<int> CreateServicePackageManual(
            CreateServicePackageManualDTO createServicePackageManualDTO,
            CancellationToken cancellationToken);
    }
}
