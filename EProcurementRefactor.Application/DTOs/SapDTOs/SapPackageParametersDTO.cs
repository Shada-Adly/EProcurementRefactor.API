namespace EProcurementRefactor.Application.DTOs.SapDTOs
{
    public class SapPackageParametersDTO
    {
        public string project_num { get; set; }

        public string datefrom { get; set; }

        public string dateTo { get; set; }

        public List<MaterialServiceDTO> inudstries { get; set; }
    }
}
