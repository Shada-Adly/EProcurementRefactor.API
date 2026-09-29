using EProcurementRefactor.Domain.Entities;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IJWTGenerator
    {
        string GenerateToken(SiacAdmin siacAdmin);
    }
}
