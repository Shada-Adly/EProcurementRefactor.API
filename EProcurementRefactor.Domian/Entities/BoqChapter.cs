using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class BoqChapter
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public short? BoqId { get; set; }

    public virtual BoqStandard? Boq { get; set; }

    public virtual ICollection<ProjPackage> ProjPackages { get; set; } = new List<ProjPackage>();
}
