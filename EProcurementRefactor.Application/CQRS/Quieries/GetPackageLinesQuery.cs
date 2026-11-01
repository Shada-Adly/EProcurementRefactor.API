using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;

namespace EProcurementRefactor.Application.CQRS.Quieries
{
    public record GetPackageLinesQuery(SapPackageParametersDTO SapPackageParametersDTO)
        : IQueryRequest<List<IPackageLinesCommonProperitiesInterface>>
    {
    } 
}
