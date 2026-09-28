using EProcurementRefactor.Domain.Entities;

namespace EProcurementRefactor.Application.Interfaces
{
    public interface IjwtTokenGenerator
    {
        string GenerateToken(SiacAdmin siacAdmin);
    }
}
