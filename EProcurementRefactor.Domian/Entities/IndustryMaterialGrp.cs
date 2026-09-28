using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class IndustryMaterialGrp
{
    public int Id { get; set; }

    public string? MtrGrpCode { get; set; }

    public string? MtrGrpDesc { get; set; }

    public int? IndustryId { get; set; }

    public int? ServiceId { get; set; }

    public virtual ServicesIndustry? Industry { get; set; }

    public virtual ServiceHeader? Service { get; set; }
}
