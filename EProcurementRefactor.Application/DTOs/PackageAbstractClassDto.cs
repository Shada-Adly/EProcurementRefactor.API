using Microsoft.AspNetCore.Http;

namespace EProcurementRefactor.Application.DTOs
{
    public abstract class PackageAbstractClassDto
    {
        public string package_name { get; set; }

        public char assign_type { get; set; }

        public int project_id { get; set; }

        public int industry_id { get; set; }

        public int assigned_by { get; set; }

        //public IFormFile file { get; set; } = null!;
        //public string? filePath { get; set; }
        public string currency { get; set; }

        public char type { get; set; }
        public DateTime expiration_date { get; set; }
    }
}



