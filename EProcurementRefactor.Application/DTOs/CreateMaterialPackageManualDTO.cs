using Microsoft.AspNetCore.Http;

namespace EProcurementRefactor.Application.DTOs
{
    public class CreateMaterialPackageManualDTO : PackageAbstractClassDto
    {
        public int? credit_period { get; set; }
        public string? credit_periodType { get; set; }
        public int? delivery_duration { get; set; }
        public string? delivery_durationType { get; set; }
        public int? execution_duration { get; set; }
        public string? execution_durationType { get; set; }
        public List<SelectedRowsDTO> selected_rows { get; set; } = new();
        public List<int> user_ids { get; set; } = new();

        // Parallel to user_id (same order), sent as risk_realism[i]
        public List<int> risk_realisms { get; set; } = new();
        //public IFormFile file { get; set; }
        //public string? filePath { get; set; }
    }
}
