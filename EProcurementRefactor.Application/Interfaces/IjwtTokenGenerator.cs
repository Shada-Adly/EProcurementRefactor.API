using EProcurementRefactor.Domain.Entities;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(SiacAdmin siacAdmin);
    }
}
