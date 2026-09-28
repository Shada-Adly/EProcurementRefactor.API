using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ProjectsTender
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? PackageName { get; set; }

    public string? PackageNumb { get; set; }

    public string? PackageStatus { get; set; }

    public DateOnly? Publishing { get; set; }

    public DateOnly? Ending { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<ProjectsTenderDetail> ProjectsTenderDetails { get; set; } = new List<ProjectsTenderDetail>();
}
