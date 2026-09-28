using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ServicesIndustry
{
    public int Id { get; set; }

    public string? IndustryCode { get; set; }

    public string? Descr { get; set; }

    public int? HeaderId { get; set; }

    public string? EnglishDesc { get; set; }

    public virtual ServiceHeader? Header { get; set; }

    public virtual ICollection<IndustryMaterialGrp> IndustryMaterialGrps { get; set; } = new List<IndustryMaterialGrp>();

    public virtual ICollection<ServiceMtrGrp> ServiceMtrGrps { get; set; } = new List<ServiceMtrGrp>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
