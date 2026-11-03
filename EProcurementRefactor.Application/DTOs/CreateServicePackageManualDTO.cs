using Microsoft.AspNetCore.Http;

namespace EProcurementRefactor.Application.DTOs
{
    public class CreateServicePackageManualDTO : PackageAbstractClassDto
    {
        public List<SelectedServiceRowsDto> selected_rows { get; set; } = new();
        public List<int> user_ids { get; set; } = new();
        public List<int> risk_realisms { get; set; } = new();
        public int? execution_duration { get; set; }
        public string? execution_durationType { get; set; }

    }
}
