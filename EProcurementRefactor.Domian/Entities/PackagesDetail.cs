namespace EProcurementRefactor.Domain.Entities;

public partial class PackagesDetail
{
    public int id { get; set; }

    public int? pkg_id { get; set; }

    public int? user_id { get; set; }

    public string? pr_num { get; set; }

    public string? line_item { get; set; }

    public DateOnly? pr_date { get; set; }

    public string? mtr_code { get; set; }

    public string? mtr_desc { get; set; }

    public string? mtr_long_desc { get; set; }

    public string? mtr_batch { get; set; }

    public string? mtr_qty { get; set; }

    public string? mtr_uom { get; set; }

    public string? m_grp { get; set; }

    public DateTime? inserted_date { get; set; }

    public string? serial { get; set; }

    public virtual PackagesHeader? pkg { get; set; }
}
