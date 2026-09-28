using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class UsersBidding
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? DateInserted { get; set; }

    public int? PkgId { get; set; }

    public string? FilePath { get; set; }

    public virtual ProjPackage? Pkg { get; set; }

    public virtual UserHeader? User { get; set; }
}
