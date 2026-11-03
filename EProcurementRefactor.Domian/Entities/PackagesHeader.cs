using EProcurementRefactor.Domian.Enums;

namespace EProcurementRefactor.Domain.Entities;

public partial class PackagesHeader
{
    public int id { get; set; }

    public string? pkg_name { get; set; }

    public char assign_type { get; set; }

    public int project_id { get; set; }

    public int industry_id { get; set; }

    public DateTime? inserted_date { get; set; }

    public bool? bid { get; set; }

    public bool? cancelled { get; set; }

    public int pkg_num { get; set; }

    public int? assigned_by { get; set; }

    public string? file_path { get; set; }

    public bool? excl_import { get; set; }

    public bool? is_service { get; set; }

    public string? currency { get; set; }
    public char? type { get; set; }
    public int? credit_period { get; set; }
    public PeriodType? credit_periodType { get; set; }
    public int? delivery_duration { get; set; }
    public PeriodType? delivery_durationType { get; set; }
    public DateTime? expiration_date { get; set; }
    public int? execution_duration { get; set; }
    public PeriodType? execution_durationType { get; set; }
   // public int PackageNum { get; set; }
    public virtual ICollection<AcceptedOffer> AcceptedOffers { get; set; } = new List<AcceptedOffer>();

    public virtual ICollection<PackagesDetail> PackagesDetails { get; set; } = new List<PackagesDetail>();
}
