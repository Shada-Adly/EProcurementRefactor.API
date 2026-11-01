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
    }
}
