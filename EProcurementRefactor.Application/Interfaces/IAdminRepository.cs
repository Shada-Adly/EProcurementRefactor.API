using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Domain.Entities;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IAdminRepository
    {
        Task<SiacAdmin> Login(AdminLoginDto adminLoginDto, CancellationToken cancellationToken);
    }
}
