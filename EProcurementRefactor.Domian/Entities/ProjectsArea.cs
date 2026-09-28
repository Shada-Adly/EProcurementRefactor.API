using System;
using System.Collections.Generic;

namespace EProcurementRefactor.Domain.Entities;

public partial class ProjectsArea
{
    public int Id { get; set; }

    public string? AreaName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
