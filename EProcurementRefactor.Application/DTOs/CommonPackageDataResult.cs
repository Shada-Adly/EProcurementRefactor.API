using EProcurementRefactor.Domain.Entities;

namespace EProcurementRefactor.Application.DTOs
{
    public class CommonPackageDataResult
    {
        public PackagesHeader CommonPackageHeader { get; set; } = null!;
        public int max_id { get; set; }
        public string industryResult { get; set; } = null!;
    }
}
