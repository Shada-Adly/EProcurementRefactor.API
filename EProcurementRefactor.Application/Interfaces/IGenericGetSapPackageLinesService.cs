using EProcurementRefactor.Application.DTOs.SapDTOs;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IGenericGetSapPackageLinesService
    {
        Task<List<T>> GetPackageLinesAsync<T>(
            SapPackageParametersDTO parameters,
            string apiUrl)
            where T : IPackageLinesCommonProperitiesInterface;
    }
}