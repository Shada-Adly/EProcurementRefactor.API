using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class SapProjectsStorloc
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? StorageLocation { get; set; }

    public virtual SapProject? Project { get; set; }
}
