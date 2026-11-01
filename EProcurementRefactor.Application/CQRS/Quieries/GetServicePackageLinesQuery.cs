using EProcurementRefactor.Application.Common.Mediator;
using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.DTOs.SapDTOs;

namespace EProcurementRefactor.Application.CQRS.Quieries
{
     public record GetServicePackageLinesQuery(SapPackageParametersDTO SapPackageParametersDTO)
       : IQueryRequest<List<ServicePackageLinesResponseDto>>;   
}
