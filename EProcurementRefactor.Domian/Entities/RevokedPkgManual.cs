using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class RevokedPkgManual
{
    public int Id { get; set; }

    public int? PkgId { get; set; }

    public DateTime? InsertedDate { get; set; }

    public virtual PackageManual? Pkg { get; set; }
}
