using Microsoft.AspNetCore.Http;

namespace EProcurementRefactor.Application.DTOs
{
    public class CreateMaterialPackageDto : PackageAbstractClassDto
    {
        public int? credit_period { get; set; }
        public string? credit_periodType { get; set; }
        public int? delivery_duration { get; set; }
        public string? delivery_durationType { get; set; }
        public List<SelectedRowsDTO> selected_rows { get; set; } = new();
    }
}

