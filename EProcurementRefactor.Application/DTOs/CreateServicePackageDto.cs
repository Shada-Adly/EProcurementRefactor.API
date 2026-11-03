namespace EProcurementRefactor.Application.DTOs
{
    public class CreateServicePackageDto : PackageAbstractClassDto
    {
        public int? execution_duration { get; set; }
        public int? execution_durationType { get; set; }
        public List<SelectedServiceRowsDto> selected_rows { get; set; }
    }
}
