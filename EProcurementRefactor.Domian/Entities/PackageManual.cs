using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class PackageManual
{
    public int Id { get; set; }

    public string? Serial { get; set; }

    public string? MaterialDescription { get; set; }

    public string? Uom { get; set; }

    public string? Qty { get; set; }

    public int? ProjectId { get; set; }

    public int? IndustryId { get; set; }

    public string? PackageName { get; set; }

    public int? PackNo { get; set; }

    public virtual ICollection<RevokedPkgManual> RevokedPkgManuals { get; set; } = new List<RevokedPkgManual>();
}
