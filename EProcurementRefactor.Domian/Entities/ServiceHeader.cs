using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ServiceHeader
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnglishDesc { get; set; }

    public virtual ICollection<IndustryMaterialGrp> IndustryMaterialGrps { get; set; } = new List<IndustryMaterialGrp>();

    public virtual ICollection<ServicesIndustry> ServicesIndustries { get; set; } = new List<ServicesIndustry>();
}
