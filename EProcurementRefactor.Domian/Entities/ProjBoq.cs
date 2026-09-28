using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ProjBoq
{
    public int? ProjId { get; set; }

    public short? BoqId { get; set; }

    public virtual BoqStandard? Boq { get; set; }

    public virtual Project? Proj { get; set; }
}
