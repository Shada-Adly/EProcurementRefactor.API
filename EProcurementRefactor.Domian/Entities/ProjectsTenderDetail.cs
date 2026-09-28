using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ProjectsTenderDetail
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int? PackageId { get; set; }

    public string? DocumentfileName { get; set; }

    public string? DocumentfilePath { get; set; }

    public string? Details { get; set; }

    public string? Description { get; set; }

    public virtual ProjectsTender? Package { get; set; }

    public virtual Project Project { get; set; } = null!;
}
